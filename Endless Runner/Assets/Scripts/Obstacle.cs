using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class Obstacle : MonoBehaviour {

    private float _SPEED = -5;

	// Use this for initialization
	void Start () {
        _SPEED = Constants.GetFloat("SPEED");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        transform.Translate(_SPEED / 30, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "DestroyObstacle")
        {
            Destroy(gameObject);
        }
    }
}
