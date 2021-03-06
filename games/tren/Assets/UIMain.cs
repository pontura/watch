using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour {

	public UIEditing uiEditing;
	public UIPlaying uiPlaying;
	public Train train;

	void Start()
	{
		EditGame ();
	}
	public void PlayGame()
	{
		train.state = Train.states.MOVING;
		uiPlaying.SetOn (true);
		uiEditing.SetOn (false);
	}
	public void EditGame()
	{
		train.state = Train.states.STOPPED;
		uiPlaying.SetOn (false);
		uiEditing.SetOn (true);
	}

}
