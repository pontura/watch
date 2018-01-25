using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour {

	public Transform container;
	public Character character;

	void Start () {
		
	}
	public void AddCharacter(int id, Character character)
	{		
		Character c = Instantiate (character);
		c.transform.SetParent (container);
		c.transform.localScale = Vector3.one;
		c.transform.localEulerAngles = Vector3.zero;
		c.transform.localPosition = Vector3.zero;
		c.SetCharacter (id);
		this.character = c;
	}
}
