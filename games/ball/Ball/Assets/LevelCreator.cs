using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

	public Ball ball;
	public Goal goal;
	public Fire fire;
	public Key key;
	public Transform container;

	public void Reset()
	{
		Utils.RemoveAllChildsIn (container);
	}
	public void Add(SceneObject so) {
		ObjectInScene objectInGame = null;
		switch (so.name) {
		case "Ball":
			objectInGame = ball;
			break;
		case "Goal":
			objectInGame = goal;
			break;
		case "Fire":
			objectInGame = fire;
			break;
		case "Key":
			objectInGame = key;
			break;
		}
		ObjectInScene newObj = Instantiate (objectInGame) as ObjectInScene;
		newObj.transform.SetParent (container);
		newObj.transform.localScale = Vector3.one;
		newObj.transform.localPosition = so.transform.localPosition;
	}
}
