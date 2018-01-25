using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public bool DEBUGGER;

	public Camera mainCam;
	public static Game mInstance = null;
	public UIMain uiMain;

	public states state;
	public enum states
	{
		IDLE,
		PLAYING
	}

	public static Game Instance
	{
		get
		{
			return mInstance;
		}
	}
	void Awake () {
		mInstance = this;
	}
	void Start()
	{
//		
//			mainCam.fieldOfView = 80;
//		else {
//			Screen.sleepTimeout = SleepTimeout.NeverSleep;
//			mainCam.fieldOfView = 53;
//		}
		LoadLevel ();
	}
	public void LoadLevel()
	{
	}
	public void OnStartGame()
	{
		state = states.PLAYING;
	}


}
