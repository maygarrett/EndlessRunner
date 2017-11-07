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
        if (instance)               // checking the instance getters and setters to see if they exist
        {
            DestroyImmediate(gameObject);    // if they do, destroy the object
        }
        else
        {
            instance = this;             // otherwise if instance is this current object, don't destroy

            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        Constants.Initialize();
    }

    private static CSVManager instance             // getters and setters function instance  // creating a public function to get and set value _instance
    {
        get { return _instance; }              // can also use just " get; "
        set { _instance = value; }
    }

}
