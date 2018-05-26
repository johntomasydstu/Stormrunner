using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text ScoreText; //Score Text
	public Text HighScoreText; //High Score Text

	public float scoreCount; //Score
	public float HighScoreCount; //High Score

	public float pointsPerSecond; //How much the score is increased per second

	public bool scoreIncreasing; //If the score should continue increasing

	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.GetFloat ("HighScore") != null) 
		{
			HighScoreCount = PlayerPrefs.GetFloat ("HighScore"); //Set to saved high score.
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		//Increase score if scoreIncreasing is true.
		if (scoreIncreasing) 
		{
			scoreCount += pointsPerSecond * Time.deltaTime; //Add score relative to the time inbetween each frame

		}

		//Update High Score
		if (scoreCount > HighScoreCount) //If Score > High Score:
		{
			HighScoreCount = scoreCount; //Set High Score to score.
			PlayerPrefs.SetFloat("HighScore", HighScoreCount); //Save the High Score
		}

		ScoreText.text = "Score: " + Mathf.Round(scoreCount); //Sets the score text to the score
		HighScoreText.text = "High Score: " + Mathf.Round(HighScoreCount); //Sets the high score text to the high score

	}
}
