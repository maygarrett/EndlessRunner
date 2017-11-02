using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <para>Week 2 - Mobile Input</para>
/// Example of Swiping to add Torque to a cube. Set the Angular drag on the Rigidbody to 1.
/// <author>Rocco Briganti</author>
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class SwipeScript : MonoBehaviour
{
	private const float MIN_SWIPE_LENGTH = 50f;
	private const float MAX_SWIPE_TIME = 0.35f;

	private Rigidbody _rb;
	private Vector3 _mouseStartPos;
	private float _elapsedTime;
	private bool _startTimer;

	public bool _enableFreeSwipe = true;

	void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_mouseStartPos = new Vector3(0f, 0f, 0f);
		_elapsedTime = 0f;
	}

	void Update()
	{
#if UNITY_EDITOR
		SimulateMouseSwipe();
#endif

#if UNITY_ANDROID || UNITY_IOS
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				_startTimer = true;
				_elapsedTime = 0f;
			}

			if (touch.phase == TouchPhase.Ended && _elapsedTime < MAX_SWIPE_TIME)
			{
				SpinCube(touch.deltaPosition);
			}
		}
#endif

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

	/// <summary>
	/// This will simulate both directional and free swipe using the Left mouse button.
	/// </summary>
	private void SimulateMouseSwipe()
	{
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

			SpinCube(direction);
		}
	}

	private void SpinCube(Vector3 pDirection)
	{
		// The greater your swipe the faster the cube will spin. This can also
		// represent the distance of the swipe as the magnitude is just the length
		// of the vector.
		float force = pDirection.magnitude;
		// Debug.Log("Direction Vector: " + pDirection.ToString());
		// Debug.Log("Swipe Distance: " + force);
		// Debug.Log("Valid Swipe - Elapsed Time: " + _elapsedTime);

		if (pDirection.magnitude > MIN_SWIPE_LENGTH)
		{
			// Normalize to get a unit vector.
			pDirection.Normalize();

			// Torque is applied in a CLOCK-WISE manner along each axis. If we want
			// to spin to the left based on our direction vector we need to inverse 
			// the X since moving left results in a Negative X but we need a positive
			// force amount to spin left.
			if (_enableFreeSwipe == false)
			{
				// Allows only for swipes Up, Down, Left and Right
				if (pDirection.x > 0 && pDirection.y > -0.5f && pDirection.y < 0.5f)
				{
					_rb.AddTorque(new Vector3(0f, 1f, 0f) * force * -1);
				}
				else if (pDirection.x < 0 && pDirection.y > -0.5f && pDirection.y < 0.5f)
				{
					_rb.AddTorque(new Vector3(0f, 1f, 0f) * force);
				}

				if (pDirection.y > 0 && pDirection.x > -0.5f && pDirection.x < 0.5f)
				{
					_rb.AddTorque(new Vector3(1f, 0f, 0f) * force);
				}
				else if (pDirection.y < 0 && pDirection.x > -0.5f && pDirection.x < 0.5f)
				{
					_rb.AddTorque(new Vector3(1f, 0f, 0f) * force * -1f);
				}
			}
			else
			{
				// Allows for swipe in any direction.
				_rb.AddTorque(new Vector3(0f, 1f, 0f) * -pDirection.x * force);
				_rb.AddTorque(new Vector3(1f, 0f, 0f) * pDirection.y * force);
			}
		}
	}
}
