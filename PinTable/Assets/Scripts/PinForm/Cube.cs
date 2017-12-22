using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : PinForm {

	#region Variables

	#endregion

	#region Unity

	#endregion

	#region Override

	override public void Initialize (int p_size, float p_baseSize, float p_spaceBetweenEachVoxel) {
		_geometryVerticesNumber = 8;
		_geometryTriangleNumber = 12;

		base.Initialize(p_size, p_baseSize, p_spaceBetweenEachVoxel);
	}

	override protected void GenerateVertex(int p_x, int p_z) {
		float x = p_x * (_baseSize + _spaceBetweenEachVoxel);
		float z = p_z * (_baseSize + _spaceBetweenEachVoxel);

		//Generate è points
		_vertices[_vertexIndex] = new Vector3 (x, 0f, z);
		_vertices[_vertexIndex + 1] = new Vector3 (x, _baseSize, z);
		_vertices[_vertexIndex + 2] = new Vector3 (x + _baseSize, _baseSize, z);
		_vertices[_vertexIndex + 3] = new Vector3 (x + _baseSize, 0f, z);
		_vertices[_vertexIndex + 4] = new Vector3 (x, _baseSize, z + _baseSize);
		_vertices[_vertexIndex + 5] = new Vector3 (x + _baseSize, _baseSize, z + _baseSize);
		_vertices[_vertexIndex + 6] = new Vector3 (x + _baseSize, 0f, z + _baseSize);
		_vertices[_vertexIndex + 7] = new Vector3 (x, 0f, z + _baseSize);
	}

	override protected void GenerateTriangle(int p_x, int p_z) {
		int index = ((p_x * _geometryTriangleNumber) + (p_z * _size * _geometryTriangleNumber)) * 3;

		index = GenerateQuad(index, _vertexIndex, _vertexIndex + 1, _vertexIndex + 2, _vertexIndex + 3); 

		index = GenerateQuad(index, _vertexIndex + 1, _vertexIndex + 4, _vertexIndex + 5, _vertexIndex + 2); 

		index = GenerateQuad(index, _vertexIndex + 2, _vertexIndex + 5, _vertexIndex + 6, _vertexIndex + 3); 

		index = GenerateQuad(index, _vertexIndex + 4, _vertexIndex + 1, _vertexIndex, _vertexIndex + 7); 

		index = GenerateQuad(index, _vertexIndex + 6, _vertexIndex + 5, _vertexIndex + 4, _vertexIndex + 7); 

		index = GenerateQuad(index, _vertexIndex, _vertexIndex + 3, _vertexIndex + 6, _vertexIndex + 7	); 
	}

	override protected void GenerateUV(int p_x, int p_z) {
		Vector2 uv = new Vector2 ((float)p_x / (float)_size, (float)p_z / (float)_size);

		_uvs [_vertexIndex] = uv;
		_uvs [_vertexIndex + 1] = uv;
		_uvs [_vertexIndex + 2] = uv;
		_uvs [_vertexIndex + 3] = uv;
		_uvs [_vertexIndex + 4] = uv;
		_uvs [_vertexIndex + 5] = uv;
		_uvs [_vertexIndex + 6] = uv;
		_uvs [_vertexIndex + 7] = uv;
	}

	override protected void GenerateColor() {
		Color black = Color.black;
		Color white = Color.white;

		_colors[_vertexIndex] = black;
		_colors[_vertexIndex + 1] = white;
		_colors[_vertexIndex + 2] = white;
		_colors[_vertexIndex + 3] = black;
		_colors[_vertexIndex + 4] = white;
		_colors[_vertexIndex + 5] = white;
		_colors[_vertexIndex + 6] = black;
		_colors[_vertexIndex + 7] = black;

	}

	#endregion
}