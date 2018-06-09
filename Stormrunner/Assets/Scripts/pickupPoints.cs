using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour {

	public int scoreToGive; //Amount of score to be added when collect
	private ScoreManager theScoreManager; //Score Manager

	private AudioSource coinSound; //Coin Sound

	// Use this for initialization
	void Start () 
	{
		theScoreManager = FindObjectOfType<ScoreManager> (); //Initilization

		coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource> ();; // Finds the Coin sound from the hierarchy
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

			//If Coin Sound is already playing, stop playing coin sound then start playing.
			if (coinSound.isPlaying) 
			{
				coinSound.Stop (); //Stop Coin Sound
				coinSound.Play (); //Play Coin Sound
			} 
			else 
			{
				coinSound.Play (); //Play Coin Sound
			}

		}
	}
}
