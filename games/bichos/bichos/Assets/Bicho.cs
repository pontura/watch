using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicho : MonoBehaviour {

	public int id;
	public bool orbit;
	public float speed;
	public GameObject asset;
	public GameObject pivot;
	int distance = 20;
	Animation anim;

	public void Init(float _y)
	{
		anim = GetComponent<Animation> ();
		Vector3 pos = new Vector3 (0, 0, -(distance-(Mathf.Abs(_y)/2)));
		pivot.transform.localPosition = pos;
		anim ["fly"].time = Random.Range (0, 4);
		anim.Play ("fly");
	}
}
