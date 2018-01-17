using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	MicRecorder micRecorder;

	void Start () {
		micRecorder = GetComponent<MicRecorder> ();
	}
	public void Rec()
	{
		Events.SetRecording(true);
	}
	public void StopRec()
	{
		Events.SetRecording(false);
		GetComponent<GiroscopeScreen> ().Init ();
	}
}
