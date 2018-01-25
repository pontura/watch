using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppLauncherPlugin;

public class Games : Screen {

	void OnSuccess(string message)
	{
	}

	void OnError(string message)
	{
	}

	public override void OnButtonClicked(ClockButton.types type)
	{
		switch (type) {
		case ClockButton.types.MESSAGES:
			break;
		case ClockButton.types.VIDEOS:
			break;
		}
	}

}
