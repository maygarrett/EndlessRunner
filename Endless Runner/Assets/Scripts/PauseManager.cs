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
    }

    private void UnPauseGame()
    {
        _isPaused = false;
    }

    public void PauseButtonClicked()
    {
        PauseGame();
    }

    public void ResumeButtonClicked()
    {
        UnPauseGame();
    }
}
