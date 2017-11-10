using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControls : MonoBehaviour {


    [SerializeField]
    public Slider _masterVolumeSlider;
    [SerializeField]
    private Slider _musicVolumeSlider;
    [SerializeField]
    private Slider _sfxVolumeSlider;

    private void Awake()
    {
        UpdateSliderValuesWithPlayerPrefs();
    }

    // Use this for initialization
    void Start () {

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
        UpdateSliderValuesWithCurrentVolume();
    }

    public void UpdateSliderValuesWithPlayerPrefs()
    {
        _masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        _musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        _sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void UpdateSliderValuesWithCurrentVolume()
    {
        _masterVolumeSlider.value = SoundManager.instance.GetMasterVolume();
        _musicVolumeSlider.value = SoundManager.instance.GetMusicVolume();
        _sfxVolumeSlider.value = SoundManager.instance.GetSFXVolume();
    }

    public void SaveVolumeControl()
    {
        SoundManager.instance.SaveVolumeSettings();
    }

}
