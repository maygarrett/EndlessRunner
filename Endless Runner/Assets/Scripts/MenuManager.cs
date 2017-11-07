using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private Canvas startMenu;

    [SerializeField]
    private Canvas optionsMenu;

    [SerializeField]
    private Canvas instructionsMenu;

    [SerializeField]
    private Canvas creditsMenu;

    // Use this for initialization
    void Start () {
        SoundManager.instance.PlayMusic(SoundManager.instance.GetMenuMusic());
        
        startMenu.enabled = true;
        optionsMenu.enabled = false;
        instructionsMenu.enabled = false;
        creditsMenu.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("EndlessSideScroll");
        SoundManager.instance.PlayMusic(SoundManager.instance.GetGameMusic());
        SoundManager.instance.PlaySoundEffect(SoundManager.instance.selectionClip);
    }

    public void OptionsMenu()
    {
        WhatScene().enabled = false;
        optionsMenu.enabled = true;
        SoundManager.instance.PlaySoundEffect(SoundManager.instance.selectionClip);
    }

    public void InstructionsMenu()
    {
        WhatScene().enabled = false;
        instructionsMenu.enabled = true;
        SoundManager.instance.PlaySoundEffect(SoundManager.instance.selectionClip);
    }

    public void CreditsMenu()
    {
        WhatScene().enabled = false;
        creditsMenu.enabled = true;
        SoundManager.instance.PlaySoundEffect(SoundManager.instance.selectionClip);
    }

    public void MainMenu()
    {
        WhatScene().enabled = false;
        startMenu.enabled = true;
        SoundManager.instance.PlaySoundEffect(SoundManager.instance.returnClip);

    }

    private Canvas WhatScene()
    {
        if (startMenu.enabled == true)
            return startMenu;
        else if (optionsMenu.enabled == true)
            return optionsMenu;
        else if (creditsMenu.enabled == true)
            return creditsMenu;
        else if (instructionsMenu.enabled == true)
            return instructionsMenu;
        else return startMenu;
        
    }
}
