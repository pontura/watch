using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayer : MonoBehaviour {

	public AudioClip sound1;
	public AudioClip sound2;
	public AudioClip sound3;
	public AudioClip sound4;
	public AudioClip sound5;
	public List<AudioSource> all;

	void Start () {
		Events.PlaySound += PlaySound;
	}

	void PlaySound (int id) {
		AudioClip ac = sound1;;
		switch (id) {
		case 0:
			return;
			break;
		case 1:
			ac = sound1;
			break;
		case 2:
			ac = sound2;
			break;
		case 3:
			ac = sound3;
			break;
		case 4:
			ac = sound4;
			break;
		case 5:
			ac = sound5;
			break;
		}
		AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.clip = ac;
		audioSource.Play ();
		all.Add (audioSource);
	}
	void Update()
	{
		AudioSource toDestroy = null;
		foreach (AudioSource a in all) {
			if (!a.isPlaying) {
				toDestroy = a;
			}
		}
		if (toDestroy != null) {
			all.Remove (toDestroy);
			Destroy (toDestroy);
		}
	}
}
