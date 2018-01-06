using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptions : MonoBehaviour {

	public GameObject panel;
	public GameObject[] buttons;

	void Start()
	{
		panel.SetActive (false);
	}
	public void Open(ClockItem clockItem)
	{
		panel.SetActive (true);
		panel.transform.localEulerAngles = clockItem.transform.localEulerAngles;
		foreach (GameObject go in buttons) {
			go.transform.localEulerAngles = -1*panel.transform.localEulerAngles;
		}
	}
	public void Close()
	{
		panel.SetActive (false);
	}
}
