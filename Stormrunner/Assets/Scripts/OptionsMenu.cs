using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

	public Slider musicVolumeSlider;

	public GameObject mainMenu;

	public AudioMixer theAudioMixer;

	// Use this for initialization
	void Start()
	{
		musicVolumeSlider.value = FindObjectOfType<AudioManager> ().musicVolume;
	}

	public void backButton()
	{
		
		mainMenu.SetActive(true);
		gameObject.SetActive (false);

	}
		

	public void SetMusicVolume(float value)
	{
		FindObjectOfType<AudioManager> ().musicVolume = value;
		theAudioMixer.SetFloat ("musicVol", value);
	}

	public void SetSfxVolume(float value)
	{
		FindObjectOfType<AudioManager> ().musicVolume = value;
		theAudioMixer.SetFloat ("sfxVol", value);
	}
		
}
