using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PinForm : MonoBehaviour {

	#region Variables

	/// <summary>
	/// Configuration variables
	/// </summary>
	protected int _line;
	protected int _column;
	protected float _baseSize;
	protected float _spaceBetweenEachVoxel;

	protected int _geometryVerticesNumber;
	protected int _geometryTriangleNumber;
	protected int _vertexIndex;
	protected Vector3[] _vertices;
	protected int[] _triangles;
	protected Vector3[] _uvs;
	protected Mesh _mesh;

	#endregion

	#region Methods

	public abstract void Initialize (int p_line, int p_column, float p_baseSize, float p_spaceBetweenEachVoxel);
	protected abstract void GenerateVertex (int p_x, int p_z);
	protected abstract void GenerateTriangle (int p_x, int p_z);
	protected abstract void GenerateUV ();
	protected abstract void GenerateColor();

	protected void CreateMesh (int p_x, int p_z) {
		GenerateVertex (p_x, p_z);
		GenerateTriangle (p_x, p_z);
		GenerateUV ();
		GenerateColor ();

		UpdateAllIndex ();
	}

	protected void  UpdateAllIndex () {
		_vertexIndex += _geometryVerticesNumber;
	}

	#endregion
}
