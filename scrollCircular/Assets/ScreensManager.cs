using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour {

	public Screen activeScreen;
	public Screen[] all;
	public int _width = 700;
	public bool canScrollLeft;
	public bool canScrollRight;
	public MainCamera mainCamera;

	void Start () {
		SetActiveScreenOn ();
	}

	public void ActivateNext() {
		ActivateScreen(activeScreen.ScreenToRight);
	}
	public void ActivatePrev() {
		ActivateScreen(activeScreen.ScreenToLeft);
	}
	public void ActivateScreen(Screen screen)
	{
		activeScreen = screen;
		SetActiveScreenOn ();
	}
	public void ActivatePopup(Screen screen)
	{
		activeScreen = screen;

		SetOnActiveScreen ();
		Clock.Instance.inputManager.OnPopUp();
	}
	public void ClosePopup()
	{
		print ("ClosePopup");
		Screen lastOpenedScreen = activeScreen.ScreenToLeft;
		activeScreen.SetState (false);
		activeScreen = lastOpenedScreen;
		activeScreen.SetState (true);
		activeScreen.transform.localPosition = Vector2.zero;
	}
	void SetActiveScreenOn()
	{
		foreach (Screen screen in all) {
			screen.SetState (false);
			screen.transform.localPosition = Vector2.zero;
		}
		SetOnActiveScreen ();
	}
	void SetOnActiveScreen()
	{
		activeScreen.SetState (true);
		ActivateRightLeft (activeScreen.ScreenToRight, activeScreen.ScreenToLeft);

		if(!activeScreen.isPopup)
			mainCamera.ChangeColor (activeScreen.backgroundImage.color);
	}
	Screen GetScreenByName(string name)
	{
		foreach (Screen screen in all)
			if (screen.name == name)
				return screen;
		Debug.Log ("No hay screen " + name);
		return null;
	}
	void ActivateRightLeft(Screen right, Screen left)
	{
		canScrollRight = false;
		canScrollLeft = false;
		if (right != null) {
			canScrollRight = true;
			right.SetState (true);
			right.transform.localPosition = new Vector2 (_width, 0);
		}
		if (left != null) {
			canScrollLeft = true;
			left.SetState (true);

			//muy trucho!
			if(!activeScreen.isPopup || activeScreen.name != "Call" )
				left.transform.localPosition = new Vector2 (-_width, 0);
		}
	}
}
