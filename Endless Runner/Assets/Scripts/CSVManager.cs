// CSV Manager
// attempt to try and initialize Constants so that other scripts don't need to
// author: Garrett May

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class CSVManager : MonoBehaviour {

    private static CSVManager _instance = null;

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject); 
        }
        else
        {
            instance = this; 

            DontDestroyOnLoad(this);
        }



        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            Constants.Initialize();
            Localization.Initialize();
        }
        else
        {
            Downloader.Init();
        }

    }

    private void Start()
    {

    }

    private static CSVManager instance 
    {
        get { return _instance; } 
        set { _instance = value; }
    }

}
