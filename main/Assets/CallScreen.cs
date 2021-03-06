using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallScreen : Screen {

	public Text field;
	int sec = 0;

	public override void OnScreenEnable()
	{
		field.text = "CALLING...";
		Invoke ("CalligDone", 3);
		sec = 0;
	}
	public override void OnScreenDisable()
	{
		CancelInvoke ();
	}
	void CalligDone()
	{
		field.text = "00:";
		if (sec < 10)
			field.text += "0" + sec;
		else
			field.text += sec.ToString ();
		sec++;
		Invoke ("CalligDone", 1);
	}
	public override void OnButtonClicked(ClockButton.types type)
	{
		if (Clock.Instance.inputManager.state == InputManager.states.SLIDING)
			return;
		switch (type) {
		case ClockButton.types.CANCEL_CALL:
			Clock.Instance.screensManager.ClosePopup ();
			break;
		}
	}
}
