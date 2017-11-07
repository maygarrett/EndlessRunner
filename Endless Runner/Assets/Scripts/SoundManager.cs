using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static SoundManager _instance = null;

    [SerializeField]
    private AudioClip _menuMusic;
    [SerializeField]
    private AudioClip _gameMusic;

    [SerializeField]
    private AudioSource _musicSource;

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

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
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
}
