using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class Obstacle : MonoBehaviour {

    private float _SPEED;

    [SerializeField]
    private Rigidbody2D _rb;

    private Vector2 _force;

    // Use this for initialization
    void Start()
    {
        _SPEED = Constants.GetFloat("SPEED");
        _force = new Vector2(_SPEED, 0);
        _rb.AddForce(_force);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "DestroyObstacle")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile" && this.gameObject.tag == "ObstacleTap")
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddOneToScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
