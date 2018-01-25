using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Data : MonoBehaviour
{
	public PlayerData playerData; 
    static Data mInstance = null;

    public static Data Instance
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
	{
		mInstance = this; 
        DontDestroyOnLoad(this.gameObject);
    }
	void Start()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

}
