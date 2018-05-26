using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void playGame() 
	{
		SceneManager.LoadScene ("Game"); //Loads the "Game" scene
	}

	public void quitGame() 
	{
		Application.Quit (); //Quit Game
	}
}
