using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerData : MonoBehaviour {

	public Vector3 ballPosition;
	public int keys;
	public List<DoorsData> doorsOpened;

	[Serializable]
	public class DoorsData
	{
		public string levelName;
		public int value;
		public bool isLeft;
	}
	void Start()
	{
		Events.GotKey += GotKey;
		Events.UseKey += UseKey;
	}
	void GotKey()
	{
		keys++;
	}
	void UseKey(int value, bool isLeft)
	{
		keys--;
		DoorsData data = new DoorsData ();
		data.isLeft = isLeft;
		data.value = value;
		data.levelName = Game.Instance.levelsManager.activeLevelData.name;
		doorsOpened.Add (data);
	}
	public void ResetLevelData()
	{
		keys = 0;
		doorsOpened.Clear ();
		ballPosition = Vector3.zero;
	}

}
