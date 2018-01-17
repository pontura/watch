using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public states state;
	public enum states
	{
		IDLE,
		SCROLL,
		SLIDING,
		SNAPPING_SLIDE,
		ON_POPUP
	}
	int clockWidth = 400;
	int offsetToSwipe = 60;
	float snapValue;
	float GotoSnapValue;
	public Plane playerPlane;
	public float dir;
	float startingX;
	public Clock clock;
	float actualPos = 0;
	public GameObject arrowClock;
	public int laps;
	ScreensManager screensManager;
	public Transform targetToSwipe;

	void Start()
	{
		screensManager = clock.screensManager;
		snapValue = 525;
	}
	void Update () {
		if (state == states.ON_POPUP)
			UpdateSwipe ();
		else if (state == states.SNAPPING_SLIDE) 
			Snap ();			
		else if(!insideSwipeArea && screensManager.activeScreen.isScroll)
			UpdateScroll ();

		UpdateSwipe ();
	}
	public void OnPopUp()
	{
		state = states.ON_POPUP;
		clock.scroller.Stopped ();
	}
	public void OnPopClose()
	{
		state = states.IDLE;
	}
	public void StartScroll()
	{
		laps = 0;
		clock.scroller.UpdateSlide (-180);
		state = states.SCROLL;
	}
	bool insideSwipeArea;
	void UpdateSwipe()
	{
		if (Input.GetMouseButtonDown (0) ) {
			startingX = Input.mousePosition.x;
			print (startingX);
			print (Mathf.Abs (startingX - (clockWidth / 2)));
			print ("offsetToSwipe: " + offsetToSwipe);
			if (Mathf.Abs (startingX - (clockWidth / 2)) > (clockWidth/2)-offsetToSwipe) {
				Events.OnSwipe (true);
				insideSwipeArea = true;
			}
			actualPos = 0;
		} else if (Input.GetMouseButton (0) && insideSwipeArea) {
			float realPos =(Input.mousePosition.x - startingX);
			float diff = (actualPos - realPos); //*(1+ (Time.deltaTime*4));
			if (diff != 0) {	
				Vector2 pos = targetToSwipe.transform.localPosition;
				if (pos.x < 0 && !screensManager.canScrollRight
				    ||
				    pos.x > 0 && !screensManager.canScrollLeft) {
					pos.x -= diff * (8*Time.deltaTime);
				}else{				
					pos.x -= diff * (50*Time.deltaTime);
				}
				actualPos = realPos;

				if (pos.x < -50 && !screensManager.canScrollRight
					||
					pos.x > 50 && !screensManager.canScrollLeft)
					return;

				if (screensManager.activeScreen.isPopup && pos.x < 0)
					return;
				targetToSwipe.transform.localPosition = pos;
				state = states.SLIDING;
			}
		}
		else if (Input.GetMouseButtonUp (0) && insideSwipeArea) {
			insideSwipeArea = false;
			if (targetToSwipe.transform.localPosition.x > snapValue/6)
				ActivateSwipe (1);
			else if (targetToSwipe.transform.localPosition.x < -snapValue/6)
				ActivateSwipe(-1);
			else
				ActivateSwipe(0);
		}
	}
	void ActivateSwipe(int direction)
	{
		if (direction == 1)
			GotoSnapValue = snapValue;
		else if (direction == -1)
			GotoSnapValue = -snapValue;
		else
			GotoSnapValue = 0;
		state = states.SNAPPING_SLIDE;
	}
	void Snap()
	{
		Vector2 pos = targetToSwipe.transform.localPosition;
		targetToSwipe.transform.localPosition = Vector2.Lerp (pos, new Vector2(GotoSnapValue,0), 0.3f);
		if (Mathf.Abs (targetToSwipe.transform.localPosition.x - GotoSnapValue) < 1) {
			state = states.IDLE;
			if (screensManager.activeScreen.isPopup && targetToSwipe.transform.localPosition.x > 100)
			{
				screensManager.ClosePopup ();
			}
			else if (targetToSwipe.transform.localPosition.x < -100)
				screensManager.ActivateNext ();
			else if (targetToSwipe.transform.localPosition.x > 100)
				screensManager.ActivatePrev ();
			targetToSwipe.transform.localPosition = Vector3.zero;
			Events.OnSwipe (false);
		}
	}
	bool isNewMenu;
	void UpdateScroll () {
		if (Input.GetMouseButtonDown (0) ) {
			startingX = (-1*arrowClock.transform.localEulerAngles.z);
			actualPos = 0;
			isNewMenu = true;
		} else if (Input.GetMouseButton (0)) {
			float realRot =(-1* arrowClock.transform.localEulerAngles.z - startingX);
			float diff = (actualPos - realRot)*(1+ (Time.deltaTime*4));
			if (diff != 0) {	
				if (isNewMenu) {
					clock.scroller.Clicked();
					isNewMenu = false;
				}
				if (diff > 50 || diff < -50)  {
					//ignore:
				} else {
					clock.scroller.UpdateSlide (-diff);
				}
				actualPos = realRot;
				clock.scroller.state = Scroller.states.SLIDING;
			}
		}
		else if (Input.GetMouseButtonUp (0)) {
			dir = 0;
			clock.scroller.Snap ();
		}
			
	}
}
