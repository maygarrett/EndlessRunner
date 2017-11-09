using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class LocalizationManager : MonoBehaviour {

    private static LocalizationManager _instance = null;

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
        Localization.Initialize();
    }

    private void Start()
    {
        //Constants.Initialize();
    }

    private static LocalizationManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

}
