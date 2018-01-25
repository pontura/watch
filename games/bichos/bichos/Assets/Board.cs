using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	public UIMain ui;
	public GameObject board;

	public void UpdateRotation(Quaternion rot)
	{
		//board.transform.localRotation = rot;
		//ui.SetField (rot.ToString());
	}
}
