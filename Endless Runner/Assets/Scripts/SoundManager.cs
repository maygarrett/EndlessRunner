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


    private void Awake()
    {
        // get audio mixers volume from playerprefs and set the mixer volumes to those values (Volume controls will set the sliders accordingly)



    }


    // Use this for initialization
    void Start () {
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


        // initialization
        PlayMusic(_menuMusic);
    }
	
	// Update is called once per frame
	void Update () {
		
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
        _audioMixer.SetFloat("MusicVolume", pVolume);
    }

    public void SetSFXVolume(float pVolume)
    {
        _audioMixer.SetFloat("SFXVolume", pVolume);
    }

    public void SetMasterVolume(float pVolume)
    {
        _audioMixer.SetFloat("Master", pVolume);
    }

    public float GetMasterVolume()
    {
        float tempVolume;
        _audioMixer.GetFloat("Master", out tempVolume);
        return tempVolume;
    }

    public float GetMusicVolume()
    {
        float tempVolume;
        _audioMixer.GetFloat("MusicVolume", out tempVolume);
        return tempVolume;
    }

    public float GetSFXVolume()
    {
        float tempVolume;
        _audioMixer.GetFloat("SFXVolume", out tempVolume);
        return tempVolume;
    }

}
