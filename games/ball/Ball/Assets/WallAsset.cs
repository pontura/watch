using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAsset : MonoBehaviour {

	public int value;
	public bool isLeft;
	public GameObject locked;
	public types type;

	public enum types
	{
		NORMAL,
		DOOR,
		PATH
	}
	void Start()
	{
		locked.SetActive (false);
	}
	public void Init(int _value, bool _isLeft)
	{
		this.value = _value;
		this.isLeft = _isLeft;

	}
	public void SetType(types type)
	{		
		locked.SetActive (false);
		MeshRenderer meshRenderer = GetComponent<MeshRenderer> ();
		meshRenderer.material.color = Color.yellow;
		this.type = type;
		switch (type) {
		case types.DOOR:
			meshRenderer.material.color = Color.blue;
			locked.SetActive (true);
			foreach (PlayerData.DoorsData data in Data.Instance.playerData.doorsOpened) {
				if (data.value == value && data.isLeft == isLeft && Game.Instance.levelsManager.activeLevelData.name == data.levelName)
					SetType (types.PATH);
			}
			break;
		case types.PATH:
			meshRenderer.enabled = false;
			break;
		default:
			meshRenderer.enabled = true;
			break;
		}
	}

}
