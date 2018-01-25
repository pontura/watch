using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEditing : MonoBehaviour {
	public GameObject panel;
	Train train;
	void Start () {
		train = GetComponent<Train> ();
	}
	public void SetOn( bool isOn )
	{
		panel.SetActive (isOn);
		if (isOn)
			ClickRight ();
	}
	public void ClickLeft()
	{
		train.Move (true);
	}
	public void ClickRight()
	{
		train.Move (false);
	}
	public void ClickTop()
	{
		train.Change (false);
	}
	public void ClickDown()
	{
		train.Change (false);
	}
}
