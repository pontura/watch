using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockButton : MonoBehaviour {

	public types type;
	public Color color;

	public enum types
	{
		GAMES,
		MESSAGES,
		VIDEOS,
		SCROLL_CLOSE,
		PHONE,
		LIST_OF_MESSAGES,
		CANCEL_CALL
	}
	public void OnClicked()
	{
		print (type);
		Events.OnButtonClicked (type);
	}
}
