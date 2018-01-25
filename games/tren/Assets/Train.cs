using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

	public GameObject pua;
	float speed = 20;
	public Character character;
	int totalWagons = 16;
	public Wagon wagon;
	public Transform container;
	public List<Wagon> wagons;
	float rotateTo;
	public int activeWagon;

	public states state;
	public enum states
	{
		STOPPED,
		MOVING
	}

	void Start () {
		int characterId = 0;
		for (int a = 0; a < totalWagons; a++) {
			Wagon w = Instantiate (wagon);
			w.transform.SetParent (container);
			float r = a * (360 / (float)totalWagons);
			print (r);
			w.transform.Rotate(new Vector3 (0, 0, r));
			w.transform.localPosition = Vector2.zero;
			w.transform.localScale = Vector3.one;
			wagons.Add (w);

			w.AddCharacter (characterId, character);
			characterId++;
			if (characterId > 5)
				characterId = 0;
		}	
	}
	public void Move(bool left)
	{
		if (left)
			activeWagon--;
		else
			activeWagon++;

		if (activeWagon < 0)
			activeWagon = totalWagons - 1;
		else if (activeWagon > totalWagons - 1)
			activeWagon = 0;
		
		rotateTo = (360 / (float)totalWagons) * activeWagon;

		if (left && activeWagon== totalWagons-1) {
			container.transform.localEulerAngles = new Vector3 (0, 0, 359.9f);
		} else if (!left && activeWagon == 0) {
			container.transform.localEulerAngles = new Vector3 (0, 0, 0);
		}
	}
	void Update()
	{		
		if (state == states.STOPPED)
			UpdateEditing ();
		else
			UpdatePlaying ();
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		print (c.name);
	}
	void UpdatePlaying()
	{     

		float _z = Time.deltaTime*speed;
		container.Rotate (new Vector3 (0, 0, _z));
		rotateTo = container.transform.localEulerAngles.z;
	}
	void UpdateEditing()
	{		
		Vector3 newRot = new Vector3 (0, 0, rotateTo);
		container.transform.localEulerAngles = Vector3.Lerp (container.transform.localEulerAngles, newRot, 0.1f);
	}
	int characterID = 1;
	public void Change(bool up)
	{
		characterID++;
		if (characterID > 5)
			characterID = 0;

		GetActiveWeagon().character.SetCharacter (characterID);
		GetActiveWeagon ().character.Sing ();

		if (characterID == 0)
			return;
		Events.PlaySound (characterID);

	}
	Wagon GetActiveWeagon()
	{
		if (activeWagon == 0)
			return wagons [0];
		return wagons [totalWagons - activeWagon];
	}
	public void OnCharacterActiveByPua(Character character)
	{
		Events.PlaySound (character.id);
		character.Sing ();
		int id = 0;
		foreach (Wagon wagon in wagons) {
			if (wagon.character == character) {
				if (id == 0)
				{
					activeWagon = 0;
					return;
				}
				activeWagon = totalWagons - id;
				return;
			}
			id++;
		}
	}
}
