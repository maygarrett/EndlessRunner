using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    
    Rigidbody2D rb;
    LevelManager levelManager;

    Vector3 initialScale;

    private float _jumpForce;
    private Vector2 _jumpVector;

    bool isGrounded;

    // mobile swipe input variables
    private const float MIN_SWIPE_LENGTH = 50f;
    private const float MAX_SWIPE_TIME = 0.35f;
    private float _elapsedTime;
    private bool _startTimer;
    private Vector3 _mouseStartPos;

    private void Awake()
    {
        Constants.Initialize();
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        initialScale = transform.localScale;
        _elapsedTime = 0f;

        _jumpForce = Constants.GetFloat("JumpForce");
        _jumpVector = new Vector2(0, _jumpForce);
    }
	
	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR
        // PCControls();
        SimulateMobileControls();
#endif

#if UNITY_ANDROID || UNITY_IOS
        MobileControls();
#endif

    }

    private void OnCollisionEnter2D(Collision2D c)
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

    private void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private IEnumerator Resize()
    {
        yield return new WaitForSeconds(0.6f);
        transform.localScale = initialScale;
    }

    private void Slide()
    {
        transform.localScale = new Vector3(initialScale.x, initialScale.y / 2, initialScale.z);
        StartCoroutine("Resize");
    }

    private void Jump()
    {
        rb.AddForce(_jumpVector);
    }

    private void PCControls()
    {
        // jumping mechanic
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        // sliding mechanic
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isGrounded)
        {
            Slide();
        }
    }

    private void MobileControls()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _startTimer = true;
                _elapsedTime = 0f;
            }
            // if the touch ends and elapsed time was less that max swipe time
            if (touch.phase == TouchPhase.Ended && _elapsedTime < MAX_SWIPE_TIME)
            {
                // if swipe was up
                if (touch.deltaPosition.y > 0)
                    Jump();

                // if swipe was down
                if (touch.deltaPosition.y <= 0)
                    Slide();
            }
        }
        // calculate time spent swiping
        if (_startTimer)
        {
            if (_elapsedTime < MAX_SWIPE_TIME)
            {
                _elapsedTime += Time.deltaTime;
            }
            if (_elapsedTime >= MAX_SWIPE_TIME)
            {
                _startTimer = false;
            }
        }
    }

    private void SimulateMobileControls()
    {
        // swiping mechanic. Swipe up to jump, swipe down to slide
        if (Input.GetMouseButtonDown(0))
        {
            _mouseStartPos = Input.mousePosition;
            _startTimer = true;
            _elapsedTime = 0f;
        }
        if (Input.GetMouseButtonUp(0) && _elapsedTime < MAX_SWIPE_TIME)
        {
            _startTimer = false;
            Vector3 mouseEndPos = Input.mousePosition;
            Vector3 direction = (mouseEndPos - _mouseStartPos);
            // if swipe was up
            if(direction.y > 0)
                Jump();
            // if swipe was down
            if(direction.y <= 0)
                Slide();
        }
    }
















}
