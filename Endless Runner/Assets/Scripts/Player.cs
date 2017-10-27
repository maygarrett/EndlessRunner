using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    LevelManager levelManager;

    Vector3 initialScale;

    [SerializeField]
    Vector2 jumpVector;
    [SerializeField]
    bool isGrounded;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        jumpVector = new Vector2(0, 800);
        initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrounded && !Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(jumpVector);
            }
        }

        // sliding mechanic
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y / 2, initialScale.z);
            // StartCoroutine("Resize");
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localScale = initialScale;
        }
	}

    public void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if(c.gameObject.tag == "Obstacle")
        {
            levelManager.PlayerRespawn();
        }
    }

    public void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
