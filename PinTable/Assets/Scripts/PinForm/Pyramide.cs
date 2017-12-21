using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramide : PinForm {

	#region Variables

	#endregion

	#region Unity

	#endregion

	#region Override

	override protected void GenerateVertex(int p_x, int p_z) {
		float x = p_x * (_baseSize + _spaceBetweenEachVoxel);
		float z = p_z * (_baseSize + _spaceBetweenEachVoxel);

		//Generate 5 points
		_vertices[_vertexIndex] = new Vector3 (x, 0f, z);
		_vertices[_vertexIndex + 1] = new Vector3 (x, 0f, z + _baseSize);
		_vertices[_vertexIndex + 2] = new Vector3 (x + _baseSize, 0f, z + _baseSize);
		_vertices[_vertexIndex + 3] = new Vector3 (x + _baseSize, 0f, z);
		_vertices [_vertexIndex + 4] = new Vector3 (x + _baseSize / 2, _baseSize, z + _baseSize / 2);
	}

	override protected void GenerateTriangle(int p_x, int p_z) {
		int index = ((p_x * _geometryTriangleNumber) + (p_z * _size * _geometryTriangleNumber)) * 3;

		_triangles[index] = _triangles[index + 3] = _triangles[index + 6] = _triangles[index + 9] = _vertexIndex;

		_triangles[index + 5] = _triangles[index + 7] = _triangles[index + 14] = _vertexIndex + 1;

		_triangles[index + 2] = _triangles[index + 4] = _triangles[index + 12] = _triangles[index + 15] = _vertexIndex + 2;

		_triangles[index + 1] = _triangles[index + 11] = _triangles[index + 16] = _vertexIndex + 3;

		_triangles[index + 8] = _triangles[index + 10] = _triangles[index + 13] = _triangles[index + 17] = _vertexIndex + 4;
	}

	override protected void GenerateUV(int p_x, int p_z) {
		Vector2 uv = new Vector2 ((float)p_x / (float)_size, (float)p_z / (float)_size);

		_uvs [_vertexIndex] = uv;
		_uvs [_vertexIndex + 1] = uv;
		_uvs [_vertexIndex + 2] = uv;
		_uvs [_vertexIndex + 3] = uv;
		_uvs [_vertexIndex + 4] = uv;
	}

	override protected void GenerateColor() {
		Color black = new Color (0f, 0f, 0f);
		Color white = new Color (255, 255, 255);

		_colors [_vertexIndex] = black;
		_colors [_vertexIndex + 1] = black;
		_colors [_vertexIndex + 2] = black;
		_colors [_vertexIndex + 3] = black;
		_colors [_vertexIndex + 4] = white;
	}

	#endregion
}