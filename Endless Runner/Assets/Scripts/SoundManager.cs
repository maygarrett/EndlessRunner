using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    private static SoundManager _instance = null;

    // music clips
    [SerializeField]
    private AudioClip _menuMusic;
    [SerializeField]
    private AudioClip _gameMusic;

    // audio sources
    [SerializeField]
    private AudioSource _musicSource;
    [SerializeField]
    private AudioSource _fxSource;

    // sound effect clips
    public AudioClip selectionClip;
    public AudioClip returnClip;
    public AudioClip deathClip;

    // audio mixer
    [SerializeField]
    private AudioMixer _audioMixer;

    // playerpref const keys
    private const string _MASTER_VOLUME_KEY = "MasterVolume";
    private const string _MUSIC_VOLUME_KEY = "MusicVolume";
    private const string _SFX_VOLUME_KEY = "SFXVolume";

    // mixer channel keys
    private const string _MASTER_MIXER_KEY = "Master";
    private const string _MUSIC_MIXER_KEY = "MusicVolume";
    private const string _SFX_MIXER_KEY = "SFXVolume";

    // update bool used in update once
    private bool _updated = false;




    private void Awake()
    {
        // instance singleton stuff
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }



    // Use this for initialization
    void Start() {
        PlayMusic(_menuMusic);
    }

    // Update is called once per frame
    void Update() {
        if (!_updated)
        {
            UpdateCurrentVolumeWithPlayerPrefs();
            _updated = true;
        }
            
    }

    public static SoundManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public void PlayMusic(AudioClip pClip)
    {
        _musicSource.clip = pClip;
        _musicSource.Play();
    }

    public AudioClip GetGameMusic()
    {
        return _gameMusic;
    }

    public AudioClip GetMenuMusic()
    {
        return _menuMusic;
    }

    public void PauseMusic()
    {
        _musicSource.Pause();
    }

    public void ResumeMusic()
    {
        _musicSource.UnPause();
    }

    public void PlaySoundEffect(AudioClip pClip)
    {
        _fxSource.clip = pClip;
        _fxSource.Play();
    }

    public void SetMusicVolume(float pVolume)
    {
        _audioMixer.SetFloat(_MUSIC_MIXER_KEY, pVolume);
    }

    public void SetSFXVolume(float pVolume)
    {
        _audioMixer.SetFloat(_SFX_MIXER_KEY, pVolume);
        
    }

    public void SetMasterVolume(float pVolume)
    {
        _audioMixer.SetFloat(_MASTER_MIXER_KEY, pVolume);
    }

    public float GetMasterVolume()
    {
        float tempVolume;
        _audioMixer.GetFloat(_MASTER_MIXER_KEY, out tempVolume);
        return tempVolume;
    }

    public float GetMusicVolume()
    {
        float tempVolume;
        _audioMixer.GetFloat(_MUSIC_MIXER_KEY, out tempVolume);
        return tempVolume;
    }

    public float GetSFXVolume()
    {
        float tempVolume;
        _audioMixer.GetFloat(_SFX_MIXER_KEY, out tempVolume);
        return tempVolume;
    }

    public void SaveVolumeSettings()
    {
        // save seems to be setting the playerprefs fine
        PlayerPrefs.SetFloat(_MASTER_VOLUME_KEY, GetMasterVolume());
        PlayerPrefs.SetFloat(_MUSIC_VOLUME_KEY, GetMusicVolume());
        PlayerPrefs.SetFloat(_SFX_VOLUME_KEY, GetSFXVolume());
    }

    public void UpdateCurrentVolumeWithPlayerPrefs()
    {
        _audioMixer.SetFloat(_MASTER_MIXER_KEY, PlayerPrefs.GetFloat(_MASTER_VOLUME_KEY));
        _audioMixer.SetFloat(_MUSIC_MIXER_KEY, PlayerPrefs.GetFloat(_MUSIC_VOLUME_KEY));
        _audioMixer.SetFloat(_SFX_MIXER_KEY, PlayerPrefs.GetFloat(_SFX_VOLUME_KEY));
    }

}
