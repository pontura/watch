using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

    public ClockItem clockItem;
    public Transform container;
    public List<ClockItem> items;

    ClockItem lastSelectedItem;
    static Clock mInstance = null;
    public MainCamera mainCamera;

    public static Clock Instance
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
    {
        if (!mInstance)
            mInstance = this;
    }
    void Start () {
		for (int a=0; a<Data.Instance.settings.totalItems; a++)
        {
            ClockItem newClockItem = Instantiate(clockItem);
            newClockItem.transform.SetParent(container);
            newClockItem.Init(a);
            items.Add(newClockItem);
        }
	}
    void Update()
    {
        Vector3 cameraPos = mainCamera.transform.position;
        foreach (ClockItem item in items)
        {
            float distance = Vector3.Distance(cameraPos, item.transform.position);
            item.UpdatePosition(distance);
        }
    }
	public ClockItem ______GetNearestItem(float _z)
    {
        int dejaPasar = 0;
        foreach(ClockItem item in items)
        {
            if (item.transform.position.z > _z)
                dejaPasar++;
            if (dejaPasar == 3 && lastSelectedItem != item)
                SelectNewItem(item);
    }
        return null;
    }
    void SelectNewItem(ClockItem item)
    {
        if(lastSelectedItem != null)
            lastSelectedItem.UnSelected();

        lastSelectedItem = item;
        print("SelectNewItem " + item);
        item.SetSelected();
    }
}
