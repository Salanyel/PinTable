using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplacement : MonoBehaviour {

	[SerializeField]
	float _bound;

	[SerializeField]
	float _speed;
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = - Input.GetAxis ("Horizontal");
        float moveVertical = - Input.GetAxis ("Vertical");
		
		float x = transform.position.x + moveHorizontal * Time.deltaTime * _speed;
		if (x <= 1000 - _bound) {
			x = 1000 - _bound;
		} else if (x >= 1000 + _bound) {
			x = 1000 + _bound;
		}
		
		float z = transform.position.z + moveVertical * Time.deltaTime * _speed;
		if (z <= 1000 - _bound) {
			z = 1000 - _bound;
		} else if (z >= 1000 + _bound) {
			z = 1000 + _bound;
		}

		transform.position =  new Vector3(x, transform.position.y, z);
	}
}
