using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public bool paused; //Whether or not the game is paused.

	/*void Update ()
	{
		//Pause-Unpause when pause key pressed
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) //If Escape or P key pressed
		{
			if (paused) { //If Game Paused
				resumeGame (); //Resume Game
			} 
			else //If game not paused
			{
				pauseGame (); //Pause Game
			}
		}
	}*/

	public void pauseGame()
	{
		paused = true; //Game is now paused
		GameObject.FindObjectOfType<PlayerAndBiomeController>().paused = paused;
		gameObject.SetActive(true); //Opens the pause menu
		Time.timeScale = 0f; //Freezes the game
	}

	public void resumeGame()
	{
		paused = false; //Game is now unpaused
		GameObject.FindObjectOfType<PlayerAndBiomeController>().paused = paused;
		gameObject.SetActive(false); //Closes the pause menu
		Time.timeScale = 1f; //Unfreezes the game
	}

	public void RestartGame() 
	{
		paused = false; //Game is now unpaused
		GameObject.FindObjectOfType<PlayerAndBiomeController>().paused = paused;
		gameObject.SetActive(false); //Closes the pause menu
		FindObjectOfType<GameManager>().Reset(); //Finds the game manager and runs it's reset function
		Time.timeScale = 1f; //Unfreezes the game
	}

	public void QuitToMain() 
	{
		paused = false; //Game is now unpaused
		GameObject.FindObjectOfType<PlayerAndBiomeController>().paused = paused;
		Time.timeScale = 1f; //Unfreezes the game
		Time.timeScale = 1f; //Unfreezes the game
		SceneManager.LoadScene ("MainMenu"); //Loads the "Game" scene
	}
}
