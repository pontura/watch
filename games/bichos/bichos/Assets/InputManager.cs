using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	
	public Board board;
	float multiplier = 1f;

	void Start()
	{
		Input.gyro.enabled = true;
	}

	void __Update () 
	{
		float _x = -Input.gyro.rotationRateUnbiased.x*multiplier;
		float _y = -Input.gyro.rotationRateUnbiased.y*multiplier;
		float _z = -Input.gyro.rotationRateUnbiased.z*multiplier;

		if (_x < -45)
			_x = -45;
		else if (_x > 45)
			_x = 45;

		if (_y < -45)
			_y = -45;
		else if (_y > 45)
			_y = 45;

		if (_z < -45)
			_z = -45;
		else if (_z > 45)
			_z = 45;

		board.transform.Rotate (
			new Vector3(_x, _y, _z)
		);
	}
}
