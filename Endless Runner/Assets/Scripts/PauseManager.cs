using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    [SerializeField]
    private Canvas _pauseCanvas;

    private bool _isPaused;


    private void Awake()
    {
        _pauseCanvas.enabled = false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool GetPaused()
    {
        return _isPaused;
    }

    private void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0;
        _pauseCanvas.enabled = true;
        SoundManager.instance.PauseMusic();
    }

    private void UnPauseGame()
    {
        _isPaused = false;
        Time.timeScale = 1;
        _pauseCanvas.enabled = false;
        SoundManager.instance.ResumeMusic();
    }

    public void PauseButtonClicked()
    {
        PauseGame();
    }

    public void ResumeButtonClicked()
    {
        UnPauseGame();
    }

    public void MainMenuButton()
    {
        UnPauseGame();
        SceneManager.LoadScene(0);
        SoundManager.instance.PlayMusic(SoundManager.instance.GetMenuMusic());
    }
}
