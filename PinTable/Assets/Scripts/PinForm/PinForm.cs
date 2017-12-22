using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PinForm : MonoBehaviour {

	#region Variables

	/// <summary>
	/// Configuration variables
	/// </summary>
	protected int _size;
	protected float _baseSize;
	protected float _spaceBetweenEachVoxel;

	protected int _geometryVerticesNumber;
	protected int _geometryTriangleNumber;

	protected int _vertexIndex;

	protected Vector3[] _vertices;
	protected int[] _triangles;
	protected Vector2[] _uvs;
	protected Color[] _colors;

	protected Mesh _mesh;

	#endregion

	#region Methods
	protected abstract void GenerateVertex (int p_x, int p_z);
	protected abstract void GenerateTriangle (int p_x, int p_z);
	protected abstract void GenerateUV (int p_x, int p_z);
	protected abstract void GenerateColor();

	public void Initialize (int p_size, float p_baseSize, float p_spaceBetweenEachVoxel) {
		_size = p_size;
		_baseSize = p_baseSize;
		_spaceBetweenEachVoxel = p_spaceBetweenEachVoxel;

		_geometryVerticesNumber = 5;
		_geometryTriangleNumber = 6;

		if (_size * _size * _geometryVerticesNumber > 65000) {
			Debug.LogError ("Too much vertices");
			return;
		}

		_vertexIndex = 0;

		gameObject.AddComponent<MeshFilter> ();
		gameObject.AddComponent<MeshRenderer> ();

		_vertices = new Vector3[_size * _size * _geometryVerticesNumber];
		_triangles = new int[_size * _size * 3 * _geometryTriangleNumber];
		_uvs = new Vector2[_vertices.Length];
		_colors = new Color[_vertices.Length];

		for (int z = 0; z < _size; ++z) {
			for (int x = 0; x < _size; ++x) {
				CreateMesh (x, z);
			}
		}

		_mesh = new Mesh ();
		_mesh.name = "PinTable";
		_mesh.vertices = _vertices;
		_mesh.triangles = _triangles;
		_mesh.uv = _uvs;
		_mesh.colors = _colors;
		_mesh.RecalculateNormals ();

		GetComponent<MeshFilter> ().mesh = _mesh;
	}

	protected void CreateMesh (int p_x, int p_z) {	
		GenerateVertex (p_x, p_z);
		GenerateTriangle (p_x, p_z);
		GenerateUV (p_x, p_z);
		GenerateColor ();

		UpdateAllIndex ();
	}

	protected void  UpdateAllIndex () {
		_vertexIndex += _geometryVerticesNumber;
	}

	public void Destroy() {
		Destroy(_mesh);
		Destroy(GetComponent<MeshRenderer>());
		Destroy(GetComponent<MeshFilter>());
		Destroy(this);
	}

	#endregion
}
