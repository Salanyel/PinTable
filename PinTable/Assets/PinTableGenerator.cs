using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTableGenerator : MonoBehaviour {

	#region Variables

	[SerializeField]
	int _line;

	[SerializeField]
	int _column;

	[SerializeField]
	float _baseSize;

	[SerializeField]
	float _spaceBetweenEachVoxel;

	[SerializeField]
	Material _materialForMesh;

	int _geometryVerticesNumber = 5;
	int _geometryTriangleNumber = 6;

	int _vertexIndex;

	Vector3[] _vertices;
	int[] _triangles;
	Vector3[] _uvs;

	Mesh _mesh;

	#endregion

	#region Unity

	void Awake() {
		if (_line * _column * _geometryVerticesNumber > 65000) {
			Debug.LogError ("Too much vertices");
			return;
		}

		_vertexIndex = 0;

		gameObject.AddComponent<MeshFilter> ();
		gameObject.AddComponent<MeshRenderer> ();

		_vertices = new Vector3[_line * _column * _geometryVerticesNumber];
		_triangles = new int[_line * _column * 3 * _geometryTriangleNumber];

		for (int z = 0; z < _column; ++z) {
			for (int x = 0; x < _line; ++x) {
				CreatePyramide (x, z);
			}
		}
			
		_mesh = new Mesh ();

		GetComponent<MeshFilter> ().mesh = _mesh;
		GetComponent<MeshRenderer> ().material = _materialForMesh;
		_mesh.name = "PinTable";
		_mesh.vertices = _vertices;
		_mesh.triangles = _triangles;
		_mesh.RecalculateNormals ();
	}

	/*void OnDrawGizmos () {
		Gizmos.color = Color.black;
		for (int i = 0; i < _vertices.Length; i++) {
			Gizmos.DrawSphere(_vertices[i], _baseSize/10f);
		}
	}//*/

	#endregion

	#region Methods

	void CreatePyramide(int p_x, int p_z) {

		GenerateVertex (p_x, p_z);
		GenerateTriangle (p_x, p_z);
		GenerateUV ();
		GenerateColor ();

		UpdateAllIndex ();
	}

	void GenerateVertex(int p_x, int p_z) {

		float x = p_x * (_baseSize + _spaceBetweenEachVoxel);
		float z = p_z * (_baseSize + _spaceBetweenEachVoxel);

		//Generate 5 points
		_vertices[_vertexIndex] = new Vector3 (x, 0f, z);
		_vertices[_vertexIndex + 1] = new Vector3 (x, 0f, z + _baseSize);
		_vertices[_vertexIndex + 2] = new Vector3 (x + _baseSize, 0f, z + _baseSize);
		_vertices[_vertexIndex + 3] = new Vector3 (x + _baseSize, 0f, z);
		_vertices [_vertexIndex + 4] = new Vector3 (x + _baseSize / 2, _baseSize, z + _baseSize / 2);
	}

	void GenerateTriangle(int p_x, int p_z) {
		int index = ((p_x * _geometryTriangleNumber) + (p_z * _line * _geometryTriangleNumber)) * 3;

		_triangles[index] = _triangles[index + 3] = _triangles[index + 6] = _triangles[index + 9] = _vertexIndex;

		_triangles[index + 5] = _triangles[index + 7] = _triangles[index + 14] = _vertexIndex + 1;

		_triangles[index + 2] = _triangles[index + 4] = _triangles[index + 12] = _triangles[index + 15] = _vertexIndex + 2;

		_triangles[index + 1] = _triangles[index + 11] = _triangles[index + 16] = _vertexIndex + 3;

		_triangles[index + 8] = _triangles[index + 10] = _triangles[index + 13] = _triangles[index + 17] = _vertexIndex + 4;
	}

	void GenerateUV() {

	}

	void GenerateColor() {

	}

	void UpdateAllIndex() {
		_vertexIndex += _geometryVerticesNumber;
	}

	#endregion
}
