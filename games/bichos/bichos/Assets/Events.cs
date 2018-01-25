using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	
	public static System.Action OnButtonClicked = delegate { };
	public static System.Action<Bicho> CaptureBicho = delegate { };

}
