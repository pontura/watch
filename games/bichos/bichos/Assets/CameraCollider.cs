using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour {

	public List<Bicho> all;
	void Start()
	{
		Events.OnButtonClicked += OnButtonClicked;
	}
	void OnButtonClicked()
	{
		if (all.Count == 0)
			return;
		Bicho b = all [0];
		Events.CaptureBicho (b);
		all.Remove (b);
	}
	void OnTriggerEnter(Collider col)
	{
		Bicho bicho = col.GetComponentInParent<Bicho> ();
		if (!bicho)
			return;
		if(!isBichoInAll(bicho))
			all.Add (bicho);
	}
	void OnTriggerExit(Collider col)
	{
		Bicho bicho = col.GetComponentInParent<Bicho> ();
		if (!bicho)
			return;
		if(isBichoInAll(bicho))
			all.Remove (bicho);
	}
	bool isBichoInAll(Bicho _bicho)
	{
		foreach (Bicho bicho in all) {
			if (bicho == _bicho)
				return true;
		}
		return false;
	}
}
