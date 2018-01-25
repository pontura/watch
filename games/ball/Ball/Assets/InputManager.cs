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

	void Update () 
	{
		Quaternion rot = Input.gyro.attitude;
		float m = 1.25f;
		Quaternion q =  new Quaternion (-rot.x*m, -rot.z*m, -rot.y*m, rot.w);
		board.transform.rotation = q;
	}
}
