using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharactersData : MonoBehaviour {

	public List<Data> all;

	[Serializable]
	public class Data
	{
		public Color color;
		public int id;
	}
}
