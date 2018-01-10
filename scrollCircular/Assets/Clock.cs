using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

	[HideInInspector]
	public Scroller scroller;
	public ScreensManager screensManager;
	public InputManager inputManager;

    static Clock mInstance = null;


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
		inputManager = GetComponent<InputManager> ();
		scroller = GetComponent<Scroller> ();
	}
}
