using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public WallAsset wall1;
	public WallAsset wall2;

	public void Reset()
	{
		wall1.SetType (WallAsset.types.NORMAL);
		wall2.SetType (WallAsset.types.NORMAL);
	}
	public void SetData(LevelData.WallData data)
	{
		wall1.Init (data.id, data.left);
		wall2.Init (data.id, data.left);

		if (data.left) {
			if (data.door)
				wall1.SetType (WallAsset.types.DOOR);
			else if (data.link != null)
				wall1.SetType (WallAsset.types.PATH);
		} else {
			if (data.door)
				wall2.SetType (WallAsset.types.DOOR);
			else if (data.link != null)
				wall2.SetType (WallAsset.types.PATH);
		}


	}
}
