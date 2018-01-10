using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonScroll : MonoBehaviour {

	bool isOver;

	void OnMouseUp()
	{
		if (!isOver)
			return;
		ClockItem clockitem = GetComponentInParent<ClockItem> ();
		print ("last item " + Clock.Instance.scroller.lastSelectedItem.name);
		if (clockitem.isClose && Clock.Instance.scroller.lastSelectedItem.isClose)
			Events.OnButtonClicked (ClockButton.types.SCROLL_CLOSE);
	}
	void OnMouseOver()
	{
		isOver = true;
	}

	void OnMouseExit()
	{
		isOver = false;
	}
}
