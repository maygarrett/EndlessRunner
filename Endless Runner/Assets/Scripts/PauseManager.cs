using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    [SerializeField]
    private Canvas _pauseCanvas;

    private bool _isPaused;

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
    }

    private void UnPauseGame()
    {
        _isPaused = false;
        Time.timeScale = 1;
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
        SceneManager.LoadScene(0);
    }
}
