using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen : MonoBehaviour {

	public GameObject masker;
	public Screen ScreenToRight;
	public Screen ScreenToLeft;
	public bool isScroll;
	public bool isPopup;
	public Image backgroundImage;

	public void SetState(bool state) {
		gameObject.SetActive (state);
	}
	void OnEnable()
	{
		Events.OnButtonClicked += OnButtonClicked;
		OnScreenEnable ();
	}
	void OnDisable()
	{
		Events.OnButtonClicked -= OnButtonClicked;
		OnScreenDisable ();
	}
	public virtual void OnButtonClicked(ClockButton.types type)
	{
	}
	public virtual void OnScreenEnable()
	{
	}
	public virtual void OnScreenDisable()
	{
	}
}
