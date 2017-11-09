using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameData;

public class ButtonManager : MonoBehaviour {

    [SerializeField]
    private Text _START_GAME;

	// Use this for initialization
	void Start () {
        _START_GAME.text = Localization.GetString("START_GAME");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
