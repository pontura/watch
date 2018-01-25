using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pua : MonoBehaviour {

	public Train train;

	void OnTriggerEnter2D(Collider2D c)
	{
		Character character = c.gameObject.GetComponent<Character>();
		if(character == null) return;
		train.OnCharacterActiveByPua (character);
	}
}
