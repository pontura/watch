using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	public static System.Action OnStartGame = delegate { };
	public static System.Action LevelComplete = delegate { };
	public static System.Action<int> GotIntoDoor = delegate { };
	public static System.Action Die = delegate { };
	public static System.Action GotKey = delegate { };
	public static System.Action<int, bool> UseKey = delegate { };
}
