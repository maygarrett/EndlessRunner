using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {

    private static HighScoreManager _instance = null;

    private int _highScore;

    private void Awake()
    {
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
    void Start () {
		// load high score from playerprefs

	}
	
	// Update is called once per frame
	void Update () {


		
	}

    public static HighScoreManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public int GetHighScore()
    {
        return _highScore;
    }

    public void SetHighScore(int pValue)
    {
        _highScore = pValue;
    }

    public void ResetHighScore()
    {
        _highScore = 0;
    }
}
