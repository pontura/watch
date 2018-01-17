using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIntro : MonoBehaviour {

	public Canvas canvas;
	public Text field;

	public void OnIntro() {
		canvas.enabled = true;
		Invoke ("StartGame", 2);
		field.text = "Ready?";
	}

	void StartGame () {
		canvas.enabled = false;
		Events.OnStartGame ();
	}
}
