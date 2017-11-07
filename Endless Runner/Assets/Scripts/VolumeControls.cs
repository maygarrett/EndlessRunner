using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControls : MonoBehaviour {

    private SoundManager _soundManager;

	// Use this for initialization
	void Start () {
        _soundManager = GameObject.FindObjectOfType<SoundManager>();

        if(!_soundManager)
        {
            Debug.LogError("Having trouble finding SoundManager");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeMusicVolume(float pVolume)
    {
        SoundManager.instance.SetMusicVolume(pVolume);
    }

    public void ChangeSFXVolume(float pVolume)
    {
        SoundManager.instance.SetSFXVolume(pVolume);
    }

    public void ChangeMasterVolume(float pVolume)
    {
        SoundManager.instance.SetMasterVolume(pVolume);
    }
}
