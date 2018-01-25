using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichosManager : MonoBehaviour {

	public Transform container;

	int bichosTotal1 = 50;
	public Bicho bicho1;

	int bichosTotal2 = 4;
	public Bicho bicho2;

	int bichosTotal3 = 4;
	public Bicho bicho3;


	public List<Bicho> bichos;

	void Start () {
		AddBichos ();
		Events.CaptureBicho += CaptureBicho;
	}
	void CaptureBicho(Bicho bicho)
	{
		bichos.Remove (bicho);
		Destroy (bicho.gameObject);
	}
	void AddBichos()
	{
		for (int a = 0; a < bichosTotal1; a++) {
			Bicho newBicho = Instantiate (bicho1);
			Add (newBicho);
		}
		for (int a = 0; a < bichosTotal2; a++) {
			Bicho newBicho = Instantiate (bicho2);
			Add (newBicho);
		}
		for (int a = 0; a < bichosTotal3; a++) {
			Bicho newBicho = Instantiate (bicho3);
			Add (newBicho);
		}
	}
	void Add(Bicho newBicho)
	{
		newBicho.transform.SetParent (container);
		float rand = Random.Range(0,100)-50;
		rand += 10;
		rand /= 5;
		newBicho.speed = rand;
		bichos.Add (newBicho);

		float _ROT_Y = Random.Range (0, 350);
		Vector3 rot = new Vector3 (0, _ROT_Y, 0);
		newBicho.transform.localEulerAngles = rot;

		float _y = (float)(Random.Range(0,150)-150)/10;
		newBicho.transform.localPosition = new Vector3 (0, _y, 0);

		newBicho.Init (_y);
	}
	void Update () {
		foreach (Bicho bicho in bichos) {
			if (bicho.orbit) {
				Vector3 rot = bicho.transform.localEulerAngles;
				float speed = bicho.speed * Time.deltaTime;
				rot.y = speed;
				bicho.transform.Rotate (rot);
			}
		}
	}
}
