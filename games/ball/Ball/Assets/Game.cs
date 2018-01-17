using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public bool DEBUGGER;

	public Camera mainCam;
	public static Game mInstance = null;
	[HideInInspector]
	public LevelCreator levelCreator;
	[HideInInspector]
	public LevelsManager levelsManager;
	public UIIntro uiIntro;


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
		if (DEBUGGER)
			mainCam.fieldOfView = 80;
		else {
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
			mainCam.fieldOfView = 53;
		}
		
		levelsManager = GetComponent<LevelsManager> ();
		levelCreator = GetComponent<LevelCreator> ();

		Events.LevelComplete += LevelComplete;
		Events.GotIntoDoor += GotIntoDoor;
		Events.Die += Die;
		Events.OnStartGame += OnStartGame;
		uiIntro.OnIntro ();
		LoadLevel ();
	}
	public void LoadLevel()
	{
		levelsManager.Init ();
	}
	public void OnStartGame()
	{
		state = states.PLAYING;
	}
	void GotIntoDoor(int value)
	{
		print ("GotIntoDoor value " + value);
		levelsManager.GotoDoor(value);
		Invoke ("DelayToDoor", 0.2f);
	}
	void DelayToDoor()
	{
		Events.OnStartGame ();
	}
	void LevelComplete()
	{
		print ("LevelComplete");
		state = states.IDLE;
		uiIntro.OnIntro ();
		levelsManager.LoadNextLevel ();
		Data.Instance.playerData.ResetLevelData();
	}
	void Die()
	{
		print ("Die");
		state = states.IDLE;
		uiIntro.OnIntro ();
		levelsManager.Replay ();
		Data.Instance.playerData.ResetLevelData();
	}

}
