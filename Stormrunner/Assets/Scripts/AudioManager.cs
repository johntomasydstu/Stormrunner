using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour 
{

	public Sound[] sounds; //List of Music
	public AudioMixer theAudioMixer; //Audio Mixer reference


	public static AudioManager instance; //Static reference to current AudioManager in scene

	// Use this for initialization
	void Awake () {

		//If AudioManager already exists in the screen, destroy AudioManager.
		if (instance == null)
			instance = this;
		else 
		{
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);


		//Distribute variables
		foreach (Sound s in sounds) 
		{
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
			s.source.outputAudioMixerGroup = s.mixer;
		}
	}

	//Play Audio
	public void Play (string name) 
	{
		Sound s = Array.Find (sounds, sound => sound.name == name); //Find sound
		if (s == null) //If not found
		{
			Debug.LogWarning ("Sound: " + name + " not found!");
			return;
		}
		s.source.Play(); //Play Sound
	}

	//Play Audio
	public void Stop (string name) 
	{
		Sound s = Array.Find (sounds, sound => sound.name == name); //Find sound
		if (s == null) //If not found
		{
			Debug.LogWarning ("Sound: " + name + " not found!");
			return;
		}
		s.source.Stop(); //Stop sound
	}
}
