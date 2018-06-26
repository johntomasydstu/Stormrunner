using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;
	public GameObject helpMenuHolder;

	void Start()
	{
		FindObjectOfType<AudioManager>().Play("MainTheme"); //Play Death Sound
	}

	public void playGame() 
	{
		SceneManager.LoadScene ("Game"); //Loads the "Game" scene
		FindObjectOfType<AudioManager>().Stop("MainTheme"); //Stop playing Death Sound
	}

	public void optionsMenu() 
	{
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (true);
	}

	public void helpMenu() 
	{
		mainMenuHolder.SetActive (false);
		helpMenuHolder.SetActive (true);
	}

	public void quitGame() 
	{
		Application.Quit (); //Quit Game
	}
		
}
