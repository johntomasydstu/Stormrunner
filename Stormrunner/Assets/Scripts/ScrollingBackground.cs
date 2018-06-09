using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour 
{
	public float backgroundWidth;
	public float backgroundPosY;
	public float parallaxSpeed;

	private Transform cameraTransform; //Stores Camera's transform values
	private Transform[] layers; 
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;

	private float lastCameraX;

	private void Start()
	{
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;

		layers = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) 
		{
			layers [i] = transform.GetChild (i);

		}

		leftIndex = 0; //Set to the first object in layers array
		rightIndex = layers.Length - 1; //Set to very last object in layers array
	}

	private void Update()
	{
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * parallaxSpeed);

		lastCameraX = cameraTransform.position.x;

		if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)) 
		{
			ScrollLeft ();
		}

		if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone)) 
		{
			ScrollRight ();
		}

	}

	private void ScrollLeft()
	{
		//layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundWidth);
		layers [rightIndex].position = new Vector3 ((layers [leftIndex].position.x  - backgroundWidth), backgroundPosY, layers [rightIndex].position.z);

		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0) 
		{
			rightIndex = layers.Length - 1;
		}
	}

	private void ScrollRight()
	{
		//layers[leftIndex].position = Vector3.right * (layers [rightIndex].position.x + backgroundWidth);
		layers [leftIndex].position = new Vector3 ((layers [rightIndex].position.x + backgroundWidth), backgroundPosY, layers [leftIndex].position.z);
			

		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length) 
		{
			leftIndex = 0;
		}
	}




}
