using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float difficulty;

    //spawn timers
    float initialSpawnRate;
    float spawnRate = 1.0f;
    float timeSinceLastSpawn = 0.0f;

    //difficulty timers
    float initialDifficulty;
    float difficultyRate = 20.0f;
    float timeSinceLastIncrease = 0.0f;


    // obstacle prefabs
    public GameObject jumpObstacle;
    public GameObject slideObstacle;
    GameObject[] obstacles;

    // obstacle spawnpoints
    public GameObject jumpSpawnPoint;
    public GameObject slideSpawnPoint;

	// Use this for initialization
	void Start () {
        initialDifficulty = difficulty;
        initialSpawnRate = spawnRate;

        // set difficulty to 1 if it is 0
        if(difficulty == 0)
        {
            difficulty = 1.0f;
        }

        // set up array of obstacles and add in obstacles
        obstacles = new GameObject[2];
        obstacles[0] = jumpObstacle;
        obstacles[1] = slideObstacle;

		
	}
	
	// Update is called once per frame
	void Update () {
        // timing for spawning obstacles
		if(Time.time > timeSinceLastSpawn + spawnRate)
        {
            SpawnObstacle();
            timeSinceLastSpawn = Time.time;
        }

        // timing for increasing difficulty
        if(Time.time > timeSinceLastIncrease + difficultyRate)
        {
            IncreaseDifficulty();
            timeSinceLastIncrease = Time.time;
        }
	}

    public void PlayerRespawn()
    {
        difficulty = initialDifficulty;
        spawnRate = initialSpawnRate;
        timeSinceLastIncrease = Time.time;
        timeSinceLastSpawn = Time.time;
        GameObject[] currentObstacles;
        currentObstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        for(int i = 0; i < currentObstacles.Length; i++)
        {
            Destroy(currentObstacles[i]);
        }
    }

    private void SpawnObstacle()
    {
        int number = Mathf.FloorToInt(Random.Range(0.000001f, 2.0f));
        switch (number)
        {
            case 0:
                Instantiate(obstacles[number], jumpSpawnPoint.transform.position, jumpSpawnPoint.transform.rotation);
                print("spawning jump obstacle");
                break;
            case 1:
                Instantiate(obstacles[number], slideSpawnPoint.transform.position, slideSpawnPoint.transform.rotation);
                print("spawning slide obstacle");
                break;
        }
    }

    private void IncreaseDifficulty()
    {
        difficulty += 0.2f;
        if(spawnRate != 0.1)
        spawnRate -= 0.1f;
    }
}
