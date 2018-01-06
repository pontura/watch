using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public GameObject centerGameObject ;

	public Plane playerPlane;
	public float dir;
	float startingX;
	public Clock clock;
	float actualPos = 0;
	public GameObject arrowClock;
	public int laps;

	void Start()
	{
		laps = 0;
		clock.UpdateSlide (-180);
	}
	void Update () {
		if (Input.GetMouseButtonDown (0) ) {
			startingX = (-1*arrowClock.transform.localEulerAngles.z);
			actualPos = 0;
			clock.Clicked();
		} else if (Input.GetMouseButton (0)) {
			float realRot =(-1* arrowClock.transform.localEulerAngles.z - startingX);
			float diff = (actualPos - realRot)*(1+ (Time.deltaTime*4));
			if (diff != 0) {	
			if (diff > 50 || diff < -50)  {
				//ignore:
			} else {
				clock.UpdateSlide (-diff);
			}
				actualPos = realRot;
				clock.state = Clock.states.SLIDING;
			}
		}
		else if (Input.GetMouseButtonUp (0)) {
			dir = 0;
			clock.Snap ();
		}

	}
	void Update_X () {
		if (Input.touches.Length > 0) {
			
			if (Input.touches [0].phase == TouchPhase.Began) {
			}
		}
		if (Input.GetMouseButtonDown (0) ) {
			startingX = Input.mousePosition.x;
			actualPos = 0;
		} else
		if (Input.GetMouseButton (0)) {
				
			float realPos = Input.mousePosition.x - startingX;
			
			if (realPos != actualPos) {				
				clock.UpdateSlide (actualPos - realPos);
				actualPos = realPos;
				clock.state = Clock.states.SLIDING;
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			dir = 0;
			clock.Snap ();
		}
			
	}
}
