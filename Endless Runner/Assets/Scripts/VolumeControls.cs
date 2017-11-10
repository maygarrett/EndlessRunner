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

    [SerializeField]
    private Button _musicToggleButton;
    [SerializeField]
    private Button _sfxToggleButton;

    private bool _updated;
    

    private void Awake()
    {
        UpdateSliderValuesWithPlayerPrefs();
        SoundManager.instance.UpdateCurrentVolumeWithPlayerPrefs();
    }

    // Use this for initialization
    void Start () {
        _musicToggleButton.onClick.AddListener(ToggleMusic);
        _sfxToggleButton.onClick.AddListener(ToggleSFX);
    }
	
	// Update is called once per frame
	void Update () {
        if (!_updated)
        {
            SoundManager.instance.UpdateCurrentVolumeWithPlayerPrefs();
            _updated = true;
        }
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
        MusicTextStart();
        SFXTextStart();
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

    void ToggleMusic()
    {
        if (SoundManager.instance.GetMusicVolume() < -29)
        {
            _musicVolumeSlider.value = 0;
            _musicToggleButton.GetComponentInChildren<Text>().text = "Music ON";
        }
        else
        {
            _musicVolumeSlider.value = -30;
            _musicToggleButton.GetComponentInChildren<Text>().text = "Music OFF";
        }
    }

    private void MusicTextStart()
    {
        if (SoundManager.instance.GetMusicVolume() < -29)
        {
            _musicToggleButton.GetComponentInChildren<Text>().text = "Music OFF";
        }
        else
        {
            _musicToggleButton.GetComponentInChildren<Text>().text = "Music ON";
        }
    }

    void ToggleSFX()
    {
        if (SoundManager.instance.GetSFXVolume() < -29)
        {
            _sfxVolumeSlider.value = 0;
            _sfxToggleButton.GetComponentInChildren<Text>().text = "Sounds ON";
        }
        else
        {
            _sfxVolumeSlider.value = -30;
            _sfxToggleButton.GetComponentInChildren<Text>().text = "Sounds OFF";
        }
    }

    private void SFXTextStart()
    {
        if (SoundManager.instance.GetSFXVolume() < -29)
        {
            _sfxToggleButton.GetComponentInChildren<Text>().text = "Sounds OFF";
        }
        else
        {
            _sfxToggleButton.GetComponentInChildren<Text>().text = "Sounds ON";
        }
    }
}
