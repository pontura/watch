using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelData : MonoBehaviour {
	
	public List<WallData> walls;

	[Serializable]
	public class WallData
	{
		public int id;
		public bool left;
		public LevelData link;
		public bool door;
	}
	public WallData GetDataByID(int id)
	{
		foreach (WallData data in walls) {
			if (id == data.id)
				return data;
		}
		return null;
	}
}
