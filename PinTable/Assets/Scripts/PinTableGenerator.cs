using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTableGenerator : MonoBehaviour {

	#region Variables

	[SerializeField]
	bool _isGeneratingAtLaunch;

	[SerializeField]
	int _size;

	[SerializeField]
	float _baseSize;

	[SerializeField]
	float _spaceBetweenEachVoxel;

	[SerializeField]
	Material _materialForMesh;

	ENUM_Geometry _geometry;
	PinForm _pinTable;

	#endregion

	void Awake() {
		if (_isGeneratingAtLaunch) {
			_geometry = ENUM_Geometry.pyramid;
			OnClickToGenerate();
		}
	}

	#region Unity

	#endregion

	#region Methods

	/// <summary>
	/// Destroy and generate the pin table
	/// </summary>
	public void OnClickToGenerate() {
		if (_pinTable != null) {
			_pinTable.Destroy();

		}

		switch (_geometry) {
			case ENUM_Geometry.cube:
				break;

			default:
				_pinTable = gameObject.AddComponent<Pyramide> ();
				break;
		}

		_pinTable.Initialize (_size, _baseSize, _spaceBetweenEachVoxel);

		GetComponent<MeshRenderer> ().material = _materialForMesh;

	}

	public void ChangeGeometry(int p_newGeometry) {
		_geometry = (ENUM_Geometry)p_newGeometry;
	}

	#endregion
}
