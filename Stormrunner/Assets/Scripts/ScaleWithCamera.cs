using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithCamera : MonoBehaviour {

	public int targetWidth;
	public float pixelsToUnits;
	
	// Update is called once per frame
	void Update () 
	{
		int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);

		Camera.main.orthographicSize = height / pixelsToUnits / 2;
	}
}
