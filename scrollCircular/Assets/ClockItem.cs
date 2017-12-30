using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockItem : MonoBehaviour {

    public GameObject asset;
    float separationY;
    public float offsetToAttach;
    public float smoothZoom;

    public void Init(int id)
    {
        

        asset.transform.localPosition = new Vector3(0, separationY, 0);
        transform.localPosition = new Vector3(0, 0, Data.Instance.settings.itemsDepthSeparation * id);
        transform.Rotate(new Vector3(0, 0, (360/Data.Instance.settings.itemsInRound) * id));
    }
    public void SetSelected()
    {
        float scaler = 1.5f;
        transform.localScale = new Vector3(scaler, scaler, scaler);
    }
    public void UnSelected()
    {
        transform.localScale = Vector3.one;
    }
    public void UpdatePosition(float distanceFromCamera)
    {
        separationY = Data.Instance.settings.clockItemSeparation;
        smoothZoom = Data.Instance.settings.smoothZoom;
        offsetToAttach = Data.Instance.settings.offsetToAttach;

        float newSeparationY = separationY;
        if (distanceFromCamera < offsetToAttach)
            newSeparationY = separationY - ((offsetToAttach - distanceFromCamera)/smoothZoom);

        asset.transform.localPosition = new Vector3(0, newSeparationY, 0);
    }
}
