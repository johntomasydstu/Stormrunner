using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerAndBiomeController thePlayer; //Used to store the Player

	private Vector3 lastPlayerPosition; //Stores the Player's last x, y, z position
	private float distanceToMove; //

	// Use this for initialization
	void Start () 
	{
		
		thePlayer = FindObjectOfType <PlayerAndBiomeController> ();
		lastPlayerPosition = thePlayer.transform.position; //Sets lastPlayerPosition to the Player's position

	}
	
	// Update is called once per frame
	void Update () 
	{
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x; //Calculates the distanceToMove

		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z); //Changes the camera's x position by adding distanceToMove to the camera's x position
		lastPlayerPosition = thePlayer.transform.position; //Sets lastPlayerPosition to the Player's position
	
	}
}
