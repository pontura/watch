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
		Events.OnSwipe += OnSwipe;
		OnScreenEnable ();
	}
	void OnDisable()
	{
		Events.OnButtonClicked -= OnButtonClicked;
		Events.OnSwipe -= OnSwipe;
		OnScreenDisable ();
	}
	public virtual void OnSwipe(bool isSwiping)
	{
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
