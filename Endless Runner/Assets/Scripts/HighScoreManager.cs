using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {

    private static HighScoreManager _instance = null;

    private const string _HIGH_SCORE_KEY = "HIGH_SCORE";

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

        SetHighScore(PlayerPrefs.GetInt(_HIGH_SCORE_KEY));
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
        PlayerPrefs.SetInt(_HIGH_SCORE_KEY, pValue);
    }

    public void ResetHighScore()
    {
        _highScore = 0;
        PlayerPrefs.SetInt(_HIGH_SCORE_KEY, 0);
    }
}
