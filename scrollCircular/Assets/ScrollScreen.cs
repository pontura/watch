using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScreen : Screen {
	
	public types type;
	public Screen parentScreen;

	public enum types
	{
		MESSAGES,
		EMOJIS
	}
	public override void OnButtonClicked (ClockButton.types type)
	{
		print ("scroll " + type);
		switch (type) {
		case ClockButton.types.SCROLL_CLOSE:
			Clock.Instance.screensManager.ActivateScreen (parentScreen);
			break;
		}
	}
	public override void OnScreenDisable()
	{
		Clock.Instance.scroller.Reset ();
	}
}
