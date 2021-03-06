using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

	public ClockItem clockClose;
    public ClockItem clockItem;
	public GameObject panel;

    public Transform container;
    public List<ClockItem> items;
	public List<int> positions;
	public UIOptions uiOptions;

	public states state;
	public enum states
	{
		IDLE,
		SLIDING,
		SNAPPING,
		STOPPED
	}

	public ClockItem lastSelectedItem;
    public MainCamera mainCamera;
	public float OffsetZ = 200;
	public Color mainColor;

	void Start()
	{
		panel.SetActive (false);
	}
	public void Init(ScrollScreen.types type, Color mainColor) {
		this.mainColor = mainColor;
		panel.SetActive (true);
		for (int a=0; a<Data.Instance.settings.totalItems; a++)
        {
            ClockItem newClockItem = Instantiate(clockItem);
            newClockItem.transform.SetParent(container);
			newClockItem.Init(a, mainColor);
            items.Add(newClockItem);
			positions.Add (a * 40);
        }
		Clock.Instance.inputManager.StartScroll ();
	}
	public void Stopped()
	{
		state = states.STOPPED;
	}
	public void Reset()
	{
		Utils.RemoveAllChildsIn (container);
		state = states.IDLE;
		items.Clear ();
		positions.Clear ();
	}
	void AddClose(int id)
	{
		ClockItem newClockItem = Instantiate(clockClose);
		newClockItem.transform.SetParent(container);
		newClockItem.Init(id, mainColor);
		items.Add(newClockItem);
		positions.Add (id * 40);
		newClockItem.isClose = true;
	}

	public void UpdateSlide(float value)
	{
		Vector3 cameraPos = mainCamera.transform.position;
		cameraPos.z += value;
		Repositionate (cameraPos.z);
		ClockItem clockItem = GetNearestItem (cameraPos.z);
		if(clockItem != null)
			SelectNewItem (clockItem);
	}
	void Repositionate(float finalPos)
	{
		Vector3 cameraPos = mainCamera.transform.position;
		cameraPos.z = finalPos;

		if (cameraPos.z < -OffsetZ)
			cameraPos.z = -OffsetZ+2;
		else if (cameraPos.z > ((positions.Count)*40)-OffsetZ-2)
			cameraPos.z =((positions.Count)*40)-OffsetZ-2;

		mainCamera.transform.position =  cameraPos;
		foreach (ClockItem item in items)
		{
			float distance = Vector3.Distance(cameraPos, item.transform.position);
			item.UpdatePosition(distance);
		}

	}
	int snappingID;
	public void Snap()
	{
		snappingID = (int)Mathf.Ceil((mainCamera.transform.position.z + (OffsetZ)) / 40);
		if (snappingID > positions.Count-1)
			snappingID = positions.Count;
		snappingID--;
		state = states.SNAPPING;
		Invoke ("DelayToOpen", 0.7f);
	}
	public ClockItem GetNearestItem(float _z)
    {
		ClockItem c = items[0];
        foreach(ClockItem item in items)
        {
			if (item.transform.position.z <= _z+OffsetZ)
				c = item;
  		}
        return c;
    }
    void SelectNewItem(ClockItem item)
    {
        if(lastSelectedItem != null)
            lastSelectedItem.UnSelected();

        lastSelectedItem = item;
        item.SetSelected();
    }
	void Update()
	{
		if (state == states.STOPPED)
			return;
		if (state == states.SNAPPING) {
			Vector3 pos = mainCamera.transform.position;
			float finalPos = 0;

			if(snappingID == positions.Count-1)
				finalPos = positions[snappingID] - OffsetZ+20;
			else
				finalPos= positions[snappingID+1] - OffsetZ;
			
			float gotoPos = Mathf.Lerp (mainCamera.transform.position.z, finalPos, 0.05f);
			Repositionate (gotoPos);
			if (Mathf.Abs (mainCamera.transform.position.z - finalPos) < 1) {
				state = states.IDLE;
			}
		}
	}
	public void Clicked()
	{
		CancelInvoke ();
		uiOptions.Close ();
	}
	void DelayToOpen()
	{
		if (!lastSelectedItem.isClose) {
			uiOptions.Open (lastSelectedItem);
			lastSelectedItem.SetActiveReal ();
		}
	}
}
