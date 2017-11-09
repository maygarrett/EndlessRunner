using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameData;

public class ButtonManager : MonoBehaviour {

    [SerializeField]
    private Text _START_GAME;
    [SerializeField]
    private Text _OPTIONS_MAIN_MENU;
    [SerializeField]
    private Text _INSTRUCTIONS_MAIN_MENU;
    [SerializeField]
    private Text _CREDITS_MAIN_MENU;

    // Use this for initialization
    void Start () {
        // assign localized texts
        _START_GAME.text = Localization.GetString("START_GAME");
        _OPTIONS_MAIN_MENU.text = Localization.GetString("MAIN_MENU");
        _INSTRUCTIONS_MAIN_MENU.text = Localization.GetString("MAIN_MENU");
        _CREDITS_MAIN_MENU.text = Localization.GetString("MAIN_MENU");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
