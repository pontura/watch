using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Clock clock;
	Camera mainCamera;

	void Start () {
		mainCamera = GetComponent<Camera> ();
		Events.OnSwipe += OnSwipe;
	}
	public void ChangeColor(Color color)
	{
		mainCamera.backgroundColor = color;
	}
	void OnSwipe(bool ison)
	{
		if (!ison) {
			mainCamera.targetTexture = null;
		}
	}
	//void Update () {
       // ClockItem clockItem = clock.GetNearestItem(transform.position.z);
     //   if (clockItem == null) return;
      //  print(clockItem.transform.position.z);
     //   transform.LookAt(clockItem.asset.transform);
	//}
}
