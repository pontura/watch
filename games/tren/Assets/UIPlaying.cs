using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlaying : MonoBehaviour {

	public GameObject panel;

	public void SetOn(bool isOn) {
		panel.SetActive (isOn);
	}
}
