using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Clock clock;
	Camera mainCamera;

	void Start () {
		mainCamera = GetComponent<Camera> ();
	}
	public void ChangeColor(Color color)
	{
		mainCamera.backgroundColor = color;
	}
	//void Update () {
       // ClockItem clockItem = clock.GetNearestItem(transform.position.z);
     //   if (clockItem == null) return;
      //  print(clockItem.transform.position.z);
     //   transform.LookAt(clockItem.asset.transform);
	//}
}
