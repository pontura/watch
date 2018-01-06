using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockItem : MonoBehaviour {

	public bool isClose;
	public MeshRenderer meshRenderer;
	public MeshRenderer meshRendererBorder;
    public GameObject asset;
    float separationY;
    public float offsetToAttach;
    public float smoothZoom;
	public TextMesh field;
	public GameObject overGO;
	public SpriteRenderer thumb;
	int id;

    public void Init(int id)
    {        
		this.id = id;
		UnSelected ();
        asset.transform.localPosition = new Vector3(0, separationY, 0);
        transform.localPosition = new Vector3(0, 0, Data.Instance.settings.itemsDepthSeparation * id);
        transform.Rotate(new Vector3(0, 0, (360/Data.Instance.settings.itemsInRound) * -id));
		asset.transform.Rotate(new Vector3(0, 0, (-1*360/Data.Instance.settings.itemsInRound) * -id));
		if (field != null) {
			field.text ="";
			LoadImage ();
		}
    }
    public void SetSelected()
    {
        float scaler = 1.5f;
       // transform.localScale = new Vector3(scaler, scaler, scaler);
		overGO.SetActive (true);
		Color c = new Color (GetRandomColor(),GetRandomColor(),GetRandomColor(), 0.5f);
		//meshRenderer.material.color = c;
		//c.a = 1;
		//meshRendererBorder.material.color = c;
    }
	float GetRandomColor()
	{
		return 0;
		int rand = Random.Range (20, 100);
		return (float)rand/100;
	}
    public void UnSelected()
    {
        transform.localScale = Vector3.one;
		overGO.SetActive (false);
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
	void LoadImage()
	{
		Sprite thumbImage = Resources.Load("contacts/" + id, typeof(Sprite)) as Sprite;
		thumb.sprite = thumbImage;
	}
}
