using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
