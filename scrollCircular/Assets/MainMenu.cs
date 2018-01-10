using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppLauncherPlugin;

public class MainMenu : Screen {

	public Screen gamesScreen;
	public Screen videoScreen;

	public ScrollScreen scrollMessages;
	public ClockButton messagesButton;

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
			Clock.Instance.scroller.Init (ScrollScreen.types.MESSAGES, messagesButton.color);
			scrollMessages.parentScreen = this;
			scrollMessages.backgroundImage.color = backgroundImage.color;
			Clock.Instance.screensManager.ActivateScreen (scrollMessages);
			break;
		case ClockButton.types.VIDEOS:
			print ("video");
			Clock.Instance.screensManager.ActivatePopup (videoScreen);
			//AppLauncher.LaunchApp("com.pntura.amibots", "OnSuccess");
			break;
		case ClockButton.types.GAMES:
			Clock.Instance.screensManager.ActivatePopup (gamesScreen);
			break;
		}
	}

}
