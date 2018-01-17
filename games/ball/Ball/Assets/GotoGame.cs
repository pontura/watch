using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoGame : MonoBehaviour {

	void Start () {
		SceneManager.LoadScene ("Game");
	}
}
