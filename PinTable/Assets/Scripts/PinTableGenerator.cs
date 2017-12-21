﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTableGenerator : MonoBehaviour {

	#region Variables

	[SerializeField]
	int _size;

	[SerializeField]
	float _baseSize;

	[SerializeField]
	float _spaceBetweenEachVoxel;

	[SerializeField]
	Material _materialForMesh;

	#endregion

	#region Unity

	void Awake() {
		PinForm _pinTable = gameObject.AddComponent<Pyramide> ();
		_pinTable.Initialize (_size, _baseSize, _spaceBetweenEachVoxel);

		GetComponent<MeshRenderer> ().material = _materialForMesh;
	}

	#endregion

	#region Methods

	#endregion
}
