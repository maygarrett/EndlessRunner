using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControls : MonoBehaviour {

    private SoundManager _soundManager;

    [SerializeField]
    private Slider _masterVolumeSlider;
    [SerializeField]
    private Slider _musicVolumeSlider;
    [SerializeField]
    private Slider _sfxVolumeSlider;

    // Use this for initialization
    void Start () {
        _soundManager = GameObject.FindObjectOfType<SoundManager>();

        if(!_soundManager)
        {
            Debug.LogError("Having trouble finding SoundManager");
        }

        UpdateSliderValues();
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

    public void ResetVolumeToDefault()
    {
        SoundManager.instance.SetMusicVolume(0);
        SoundManager.instance.SetSFXVolume(0);
        SoundManager.instance.SetMasterVolume(0);
        UpdateSliderValues();
    }

    private void UpdateSliderValues()
    {
        _masterVolumeSlider.value = _soundManager.GetMasterVolume();
        _musicVolumeSlider.value = _soundManager.GetMusicVolume();
        _sfxVolumeSlider.value = _soundManager.GetSFXVolume();
    }
    
}
