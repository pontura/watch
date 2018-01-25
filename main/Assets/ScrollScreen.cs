using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScreen : Screen {
	
	public types type;
	public Screen parentScreen;
	public RawImage screenShotImage;
	public Camera mainCamera;
	public RenderTexture renderTexture;

	public enum types
	{
		MESSAGES,
		EMOJIS
	}
	public override void OnScreenEnable ()
	{
		base.OnScreenEnable ();
		screenShotImage.enabled = false;
		mainCamera.targetTexture = null;
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
	public override void OnSwipe(bool isSwiping)
	{
		SetScreenshot (isSwiping);
	}
	void SetScreenshot(bool isOn)
	{
		if(isOn)
			mainCamera.targetTexture = renderTexture;
		
		screenShotImage.enabled = isOn;
	}
}
