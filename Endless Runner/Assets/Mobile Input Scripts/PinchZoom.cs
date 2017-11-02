using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <para>Week 2 - Mobile Input</para>
/// Example of pinching to zoom a camera in and out.
/// <author>Rocco Briganti</author>
/// </summary>
public class PinchZoom : MonoBehaviour
{
	float perspectiveZPos;

	void Awake()
	{
		perspectiveZPos = Camera.main.transform.position.z;
	}

	void Update()
	{
		if (Input.touchCount == 2)
		{
			// Cache the first and second touch since we are going to reference them a lot
			Touch firstTouch = Input.GetTouch(0);
			Touch secondTouch = Input.GetTouch(1);

			// Cache the previous position of both touches from the previous frame.
			Vector2 firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
			Vector2 secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

			// Calculate the distance between touches in both the previous and current frame.
			float prevTouchDeltaMag = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
			float touchDeltaMag = (firstTouch.position - secondTouch.position).magnitude;

			// Calculate the difference between both magnitudes. If it is negative, we expect 
			// the camera to zoom in and it means the fingers are moving apart. Vice-versa
			// if otherwise.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			if (Camera.main.orthographic)
			{
				// Set the orthographic size to either the current size or 0.1 so that we don't
				// invert the camera by going into the negatives.
				Camera.main.orthographicSize += deltaMagnitudeDiff * Time.deltaTime;
				Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 5f, 20f);
			}
			else
			{
				// Clamp the camera's field of view to a min and max. Change these values to a 
				// reasonable amount dependant on the situation.
				perspectiveZPos -= deltaMagnitudeDiff * Time.deltaTime;
				perspectiveZPos = Mathf.Clamp(perspectiveZPos, -20f, -3.46f);
				Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, perspectiveZPos);
			}
		}
	}

}
