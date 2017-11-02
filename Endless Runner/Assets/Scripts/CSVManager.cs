// CSV Manager
// attempt to try and initialize Constants so that other scripts don't need to
// author: Garrett May

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class CSVManager : MonoBehaviour {

    private void Awake()
    {
        Constants.Initialize();
    }

}
