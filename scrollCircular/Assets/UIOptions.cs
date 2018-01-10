using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptions : MonoBehaviour {

	public GameObject panel;
	public GameObject[] buttons;
	public Screen phoneScreen;
	public Screen listScreen;

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
		Invoke ("DelayedClose", 0.1f);
	}
	void DelayedClose()
	{
		if (GetComponent<ScreensManager> ().activeScreen.isPopup)
			return;
		panel.SetActive (false);
	}
	void OnEnable()
	{
		Events.OnButtonClicked += OnButtonClicked;
	}
	void OnDisable()
	{
		Events.OnButtonClicked -= OnButtonClicked;
	}
	void OnButtonClicked(ClockButton.types type)
	{
		print ("Contacts " + type);
		switch (type) {
		case ClockButton.types.PHONE:
			Clock.Instance.screensManager.ActivatePopup (phoneScreen);
			break;
		}
	}
}
