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
    [SerializeField]
    private Text _TITLE;
    [SerializeField]
    private Text _OPTIONS_BUTTON;
    [SerializeField]
    private Text _OPTIONS_TITLE;
    [SerializeField]
    private Text _CREDITS_BUTTON;
    [SerializeField]
    private Text _CREDITS_TITLE;
    [SerializeField]
    private Text _INSTRUCTIONS_BUTTON;
    [SerializeField]
    private Text _INSTRUCTIONS_TITLE;
    [SerializeField]
    private Text _INSTRUCTIONS_TEXT;
    [SerializeField]
    private Text _MASTER_VOLUME_TEXT;
    [SerializeField]
    private Text _MUSIC_VOLUME_TEXT;
    [SerializeField]
    private Text _SFX_VOLUME_TEXT;
    [SerializeField]
    private Text _RESET_DEFAULTS_BUTTON;

    // Use this for initialization
    void Start () {
        // assign localized texts
        _TITLE.text = Localization.GetString("TITLE");
        _START_GAME.text = Localization.GetString("START_GAME");
        _OPTIONS_MAIN_MENU.text = Localization.GetString("MAIN_MENU");
        _INSTRUCTIONS_MAIN_MENU.text = Localization.GetString("MAIN_MENU");
        _CREDITS_MAIN_MENU.text = Localization.GetString("MAIN_MENU");
        _OPTIONS_BUTTON.text = Localization.GetString("OPTIONS_MENU");
        _OPTIONS_TITLE.text = Localization.GetString("OPTIONS_MENU");
        _CREDITS_BUTTON.text = Localization.GetString("CREDITS");
        _CREDITS_TITLE.text = Localization.GetString("CREDITS");
        _INSTRUCTIONS_BUTTON.text = Localization.GetString("INSTRUCTIONS");
        _INSTRUCTIONS_TITLE.text = Localization.GetString("INSTRUCTIONS");
        _INSTRUCTIONS_TEXT.text = Localization.GetString("INSTRUCTIONS_TEXT");
        _MASTER_VOLUME_TEXT.text = Localization.GetString("MASTER_VOLUME");
        _MUSIC_VOLUME_TEXT.text = Localization.GetString("MUSIC_VOLUME");
        _SFX_VOLUME_TEXT.text = Localization.GetString("SFX_VOLUME");
        _RESET_DEFAULTS_BUTTON.text = Localization.GetString("RESET_DEFAULTS");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
