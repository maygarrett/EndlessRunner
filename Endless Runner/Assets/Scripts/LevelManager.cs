// << level manager >>
// spawning obstacles, managing player respawn and difficulty
// author: Garrett May

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private float _difficulty;

    //spawn timers
    private float _INITIAL_SPAWN_RATE;
    [SerializeField]
    private float _spawnRate;
    private float _timeSinceLastSpawn = 0.0f;

    //difficulty timers
    private float _INITIAL_DIFFICULTY_RATE;
    [SerializeField]
    private float _difficultyRate = 20.0f;
    private float _timeSinceLastIncrease = 0.0f;


    // obstacle prefabs
    [SerializeField]
    private GameObject _jumpObstacle;
    [SerializeField]
    private GameObject _slideObstacle;
    [SerializeField]
    private GameObject _tapObstacle;

    private GameObject[] _obstacles;

    // obstacle spawnpoints
    [SerializeField]
    private GameObject _jumpSpawnPoint;
    [SerializeField]
    private GameObject _slideSpawnPoint;
    [SerializeField]
    private GameObject _tapSpawnPoint;

    // score management
    [SerializeField]
    private ScoreManager _scoreManager;

    // Use this for initialization
    void Start () {
        // setting constants from csv
        _INITIAL_SPAWN_RATE = Constants.GetFloat("INITIAL_SPAWN_RATE");
        _INITIAL_DIFFICULTY_RATE = Constants.GetFloat("INITIAL_DIFFICULTY_RATE");

        _difficultyRate = _INITIAL_DIFFICULTY_RATE;
        _spawnRate = _INITIAL_SPAWN_RATE;

        // set difficulty to 1 if it is 0
        if(_difficulty == 0)
        {
            _difficulty = 1.0f;
        }

        // set up array of obstacles and add in obstacles
        _obstacles = new GameObject[3];
        _obstacles[0] = _jumpObstacle;
        _obstacles[1] = _slideObstacle;
        _obstacles[2] = _tapObstacle;

		
	}
	
	// Update is called once per frame
	void Update () {
        // timing for spawning obstacles
		if(Time.time > _timeSinceLastSpawn + _spawnRate)
        {
            SpawnObstacle();
            _timeSinceLastSpawn = Time.time;
        }

        // timing for increasing difficulty
        if(Time.time > _timeSinceLastIncrease + _difficultyRate)
        {
            IncreaseDifficulty();
            _timeSinceLastIncrease = Time.time;
        }
	}

    public void PlayerRespawn()
    {
        _difficulty = _INITIAL_DIFFICULTY_RATE;
        _spawnRate = _INITIAL_SPAWN_RATE;
        _timeSinceLastIncrease = Time.time;
        _timeSinceLastSpawn = Time.time;
        GameObject[] tempCurrentObstacles;
        tempCurrentObstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        for(int i = 0; i < tempCurrentObstacles.Length; i++)
        {
            Destroy(tempCurrentObstacles[i]);
        }

        _scoreManager.SetScore(0);

        SoundManager.instance.PlayMusic(SoundManager.instance.GetGameMusic());
    }

    private void SpawnObstacle()
    {
        int tempNumber = Mathf.FloorToInt(Random.Range(0.000001f, _obstacles.Length));
        switch (tempNumber)
        {
            case 0:
                Instantiate(_obstacles[tempNumber], _jumpSpawnPoint.transform.position, _jumpSpawnPoint.transform.rotation);
                // print("spawning jump obstacle");
                break;
            case 1:
                Instantiate(_obstacles[tempNumber], _slideSpawnPoint.transform.position, _slideSpawnPoint.transform.rotation);
                // print("spawning slide obstacle");
                break;
            case 2:
                Instantiate(_obstacles[tempNumber], _tapSpawnPoint.transform.position, _tapSpawnPoint.transform.rotation);
                break;
        }
    }

    private void IncreaseDifficulty()
    {
        _difficulty += 0.2f;
        if(_spawnRate != 0.1)
            _spawnRate -= 0.1f;
        Debug.Log("New Difficulty Rating is: " + _difficulty);
    }
}
