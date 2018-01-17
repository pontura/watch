using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	public Transform container;
	public Wall wall;
	int totalWalls = 8;

	void Start () {
	}
	public void Init()
	{
		for (int a = 0; a < totalWalls; a++) {
			Wall newWall = Instantiate (wall);
			newWall.transform.SetParent (container);
			newWall.transform.localEulerAngles = new Vector3 (0, 0, a*(180/totalWalls));
			newWall.transform.localPosition = Vector3.zero;
		}
	}
	public void SetWalls(List<LevelData.WallData> allData)
	{		
		foreach (Wall wall in container.GetComponentsInChildren<Wall>()) {
			wall.Reset ();
		}
		foreach (LevelData.WallData data in allData) {
			int id = 0;
			foreach (Wall wall in container.GetComponentsInChildren<Wall>()) {
				if (data.id == id) {
					wall.SetData (data);
				}
				id++;
			}
		}
	}
}
