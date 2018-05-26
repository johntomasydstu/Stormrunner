using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour 
{

	public void RestartGame() 
	{
		FindObjectOfType<GameManager>().Reset(); //Finds the game manager and runs it's reset function
	}

	public void QuitToMain() 
	{
		SceneManager.LoadScene ("MainMenu"); //Loads the "Game" scene
	}

}
