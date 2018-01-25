using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public List<Image> images;
	public int id;
	public Animation anim;

	public void SetCharacter(int id)
	{
		this.id = id;
		if (id == 0) {
			foreach (Image i in images) {
				i.color = new Color (0, 0, 0, 0);
			}
			return;
		}
		foreach (Image i in images) {
			i.color = Data.Instance.charactersData.all [id - 1].color;
		}
	}
	public void Sing()
	{
		anim.Play ();
	}
}
