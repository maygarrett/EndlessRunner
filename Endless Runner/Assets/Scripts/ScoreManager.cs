using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int _INITIAL_SCORE;
    private int _score;

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _highScoreText;

    // Use this for initialization
    void Start () {
        _INITIAL_SCORE = Constants.GetInt("INITIAL_SCORE");

        _score = _INITIAL_SCORE;
        UpdateScoreText();
        UpdateHighScoreText();
	}
	
	// Update is called once per frame
	void Update () {
		if(_score > HighScoreManager.instance.GetHighScore())
        {
            HighScoreManager.instance.SetHighScore(_score);
            UpdateHighScoreText();
        }
	}

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int value)
    {
        _score = value;
        UpdateScoreText();
    }

    public void AddOneToScore()
    {
        _score += 1;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        _scoreText.text = "Score: " + GetScore();
    }


    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Obstacle")
        {
            AddOneToScore();
        }
    }

    private void UpdateHighScoreText()
    {
        _highScoreText.text = "High Score: " + HighScoreManager.instance.GetHighScore();
    }

    
}
