using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	
	public static System.Action<ClockButton.types> OnButtonClicked = delegate { };
	public static System.Action<bool> OnSwipe = delegate { };


}
