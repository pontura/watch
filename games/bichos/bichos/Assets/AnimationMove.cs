using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMove : MonoBehaviour {

	void Start () {
		GetComponent<Animation> () ["desaparecer"].time = Random.Range (0, 6);
		GetComponent<Animation> ().Play ();
	}
}
