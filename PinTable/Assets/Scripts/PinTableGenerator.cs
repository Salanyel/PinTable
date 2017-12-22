using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTableGenerator : MonoBehaviour {

	#region Variables

	[SerializeField]
	bool _isGeneratingAtLaunch;

	[SerializeField]
	ENUM_Geometry _defaultForm;

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
			_geometry = _defaultForm;
			OnClickToGenerate();
		}
	}

	#region Unity

	#endregion

	#region Methods

	/// <summary>
	/// Generate the pin table
	/// </summary>
	void Initialize() {
		switch (_geometry) {
			case ENUM_Geometry.cube:
				_pinTable = gameObject.AddComponent<Cube> ();
				break;

			default:
				_pinTable = gameObject.AddComponent<Pyramide> ();
				break;
		}

		_pinTable.Initialize (_size, _baseSize, _spaceBetweenEachVoxel);

		GetComponent<MeshRenderer> ().material = _materialForMesh;
	}

	/// <summary>
	/// Destroy and generate the pin table
	/// </summary>
	public void OnClickToGenerate() {
		if (_pinTable != null) {
			_pinTable.Destroy();
			StartCoroutine(EndOfFrameBeforeInitializing());
		} else {
			Initialize();
		}
	}

	public void ChangeGeometry(int p_newGeometry) {
		_geometry = (ENUM_Geometry)p_newGeometry;
	}

	IEnumerator EndOfFrameBeforeInitializing() {
		yield return new WaitForEndOfFrame();
		Initialize();
	}

	#endregion
}
