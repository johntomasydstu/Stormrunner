using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator; //Stores the platformGenerator
	private Vector3 platformStartPoint; //Platform's Start Point

	public PlayerController thePlayer; //Stores the Player
	private Vector3 playerStartPoint; //Player's Start point

	private PlatformDestroyer[] platformList; //List of platforms with the PlatformDestroyer script attatched

	private ScoreManager theScoreManager; //Score Manager


	public DeathMenu theDeathScreen; //Game Over Screen


	// Use this for initialization
	void Start () 
	{
		platformStartPoint = platformGenerator.position; //Set platform's start point to position of platform Generator
		playerStartPoint = thePlayer.transform.position; //Set Players's start point to Player's position. 

		theScoreManager = FindObjectOfType<ScoreManager>(); //initialize score manager
	}
		

	//Restart Game Coroutine
	public void RestartGame() 
	{
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false); //Deactivates the player - make player invisible.

		theDeathScreen.gameObject.SetActive (true); //Activates the Game Over Screen

		//StartCoroutine ("RestartGameCo"); //Runs ResartGameCoroutine
	}

	public void Reset()
	{
		theDeathScreen.gameObject.SetActive (false); //Activates the Game Over Screen
		platformList = FindObjectsOfType<PlatformDestroyer>(); //Adds all of the platforms with the PlatformDestroyer script to the platform list

		for (int i = 0; i < platformList.Length; i++) //For every object in platformList:
		{
			platformList [i].gameObject.SetActive (false); //Deactivate object
		}

		thePlayer.transform.position = playerStartPoint; //Sets the player's position to the Player's start point
		platformGenerator.position = platformStartPoint; //Sets the platformGenerator's position to the platformGenerator's start point
		thePlayer.gameObject.SetActive(true); //Reactivates the player - make player visible again.

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}

	/*//Restart Game Coroutine
	public IEnumerator RestartGameCo()
	{
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false); //Deactivates the player - make player invisible.
		yield return new WaitForSeconds (0.5f); //Delay
		platformList = FindObjectsOfType<PlatformDestroyer>(); //Adds all of the platforms with the PlatformDestroyer script to the platform list
		for (int i = 0; i < platformList.Length; i++) //For every object in platformList:
		{
			platformList [i].gameObject.SetActive (false); //Deactivate object
		}
		thePlayer.transform.position = playerStartPoint; //Sets the player's position to the Player's start point
		platformGenerator.position = platformStartPoint; //Sets the platformGenerator's position to the platformGenerator's start point
		thePlayer.gameObject.SetActive(true); //Reactivates the player - make player visible again.

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}*/
}
