﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClock : MonoBehaviour {

	public GameObject arrow;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint(arrow.transform.localPosition);
		var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
