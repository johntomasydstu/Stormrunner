using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

	public Slider musicVolumeSlider;

	public GameObject mainMenu;

	public AudioMixer theAudioMixer;



	public void backButton()
	{
		
		mainMenu.SetActive(true);
		gameObject.SetActive (false);

	}
		

	public void SetMusicVolume(float value)
	{
		theAudioMixer.SetFloat ("musicVol", value);
	}

	public void SetSfxVolume(float value)
	{
		theAudioMixer.SetFloat ("sfxVol", value);
	}
		
}
