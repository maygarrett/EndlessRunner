using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <para>Week 2 - Mobile Input</para>
/// Example script to move an object using Touch Input.
/// <author>Rocco Briganti</author>
/// </summary>
public class MoveScript : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{

#if UNITY_EDITOR
		for (int i = 0; i < 3; i++)
		{
			if (Input.GetMouseButton(i))
			{
				MoveTo(Input.mousePosition);
			}
		}
#endif

#if UNITY_IOS || UNITY_ANDROID
		if (Input.touchCount == 1)
		{
			MoveTo(Input.GetTouch(0).position);
		}
#endif
	}

	///<summary>
	/// Moves the object this script is attached to to the appropriate world 
	/// position based on touch input.
	/// </summary>
	private void MoveTo(Vector3 pTouchPos)
	{
		// First we calculate the difference between our object's Z position
		// and the Camera's Z position.
		float zPos = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

		// Our screen position will be a vector made up of our Touch X and Y
		// as well as that Z position calculated before. Giving a Z position will 
		// allow the ScreenToWorldPoint function on the camera to properly take 
		// into account depth for perspective cameras and 1 to 1 matching.
		Vector3 posToConvert = new Vector3(pTouchPos.x, pTouchPos.y, zPos);

		// Convert our new screen position to a world position.
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(posToConvert);

		// Set our objects position to that new position with the object's Z
		// position so it maintains the same DEPTH positioning.
		transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);
	}
}
