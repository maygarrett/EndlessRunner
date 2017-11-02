using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    
    private Rigidbody2D _rb;
    private LevelManager _levelManager;

    private Vector3 _initialScale;

    private float _jumpForce;
    private Vector2 _jumpVector;

    private bool _isGrounded;

    // mobile swipe input variables
    private float _MIN_SWIPE_LENGTH;
    private float _MAX_SWIPE_TIME;
    private float _elapsedTime;
    private bool _startTimer;
    private Vector3 _mouseStartPos;

    private void Awake()
    {
        Constants.Initialize();
    }

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _levelManager = GameObject.FindObjectOfType<LevelManager>();
        _initialScale = transform.localScale;
        _elapsedTime = 0f;

        // assign constants
        _jumpForce = Constants.GetFloat("JumpForce");
        _jumpVector = new Vector2(0, _jumpForce);
        _MIN_SWIPE_LENGTH = Constants.GetFloat("MIN_SWIPE_LENGTH");
        _MAX_SWIPE_TIME = Constants.GetFloat("MIN_SWIPE_LENGTH");
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
            _isGrounded = true;
        }

        if(c.gameObject.tag == "Obstacle")
        {
            _levelManager.PlayerRespawn();
        }
    }

    private void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }

    private IEnumerator Resize()
    {
        yield return new WaitForSeconds(0.6f);
        transform.localScale = _initialScale;
    }

    private void Slide()
    {
        transform.localScale = new Vector3(_initialScale.x, _initialScale.y / 2, _initialScale.z);
        StartCoroutine("Resize");
    }

    private void Jump()
    {
        _rb.AddForce(_jumpVector);
    }

    private void PCControls()
    {
        // jumping mechanic
        if (_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        // sliding mechanic
        if (Input.GetKeyDown(KeyCode.DownArrow) && !_isGrounded)
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
            if (touch.phase == TouchPhase.Ended && _elapsedTime < _MAX_SWIPE_TIME)
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
            if (_elapsedTime < _MAX_SWIPE_TIME)
            {
                _elapsedTime += Time.deltaTime;
            }
            if (_elapsedTime >= _MAX_SWIPE_TIME)
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
        if (Input.GetMouseButtonUp(0) && _elapsedTime < _MAX_SWIPE_TIME)
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
