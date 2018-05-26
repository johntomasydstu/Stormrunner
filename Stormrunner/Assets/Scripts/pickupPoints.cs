using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour {

	public int scoreToGive; //Amount of score to be added when collect
	private ScoreManager theScoreManager; //Score Manager

	// Use this for initialization
	void Start () 
	{
		theScoreManager = FindObjectOfType<ScoreManager> (); //Initilization
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") //If colliding with player:
		{
			theScoreManager.AddScore (scoreToGive); //Add Score
			gameObject.SetActive(false); //Disable Object
		}
	}
}
