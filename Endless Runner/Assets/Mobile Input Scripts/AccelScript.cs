using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <para>Week 2 - Mobile Input</para>
/// Example Accelermeter script. Tilting your device will allow you to rotate the Cube.
/// <author>Rocco Briganti</author>
/// </summary>
public class AccelScript : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		// Acceleration is a normalized Vector3 containing values from -1, to 1.
		// Accelerometer Z is flipped on your device compared to Unity Z.
		// Therefore we need the inverse of the Accelerometers Z for a consistent 
		// result on screen.
		transform.Translate(Input.acceleration.x * Time.deltaTime, 0, Input.acceleration.z * Time.deltaTime * -1f, Space.World);
	}
}
