using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiroscopeScreen : MonoBehaviour {

	public Text debbugText;
	bool isOn;
	public AudioSource audioSource;
	float value = 1;

	public void Init() {
		Input.gyro.enabled = true;
		isOn = true;
	}
	void Update () {
		if (!isOn)
			return;
		value += Input.gyro.rotationRate.x / 10;
		if (value > 3)
			value = 3;
		else if (value < -3)
			value = -3;
		debbugText.text = value.ToString();
		audioSource.pitch = value;
	}
}
