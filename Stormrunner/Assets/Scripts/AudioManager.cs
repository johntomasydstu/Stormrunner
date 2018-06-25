using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour 
{

	public Sound[] sounds; //List of Music
	public float musicVolume = 0.6f; 
	public AudioMixer theAudioMixer; //Audio Mixer reference



	public static AudioManager instance; //Static reference to current AudioManager in scene

	// Use this for initialization
	void Awake () {

		if (instance == null)
			instance = this;
		else 
		{
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);

		foreach (Sound s in sounds) 
		{
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;
			s.volume = musicVolume;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
			s.source.outputAudioMixerGroup = s.mixer;
		}
	}

	// Update is called once per frame
	public void Play (string name) 
	{
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) 
		{
			Debug.LogWarning ("Sound: " + name + " not found!");
			return;
		}
		s.source.Play();
	}

	public void Stop (string name) 
	{
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) 
		{
			Debug.LogWarning ("Sound: " + name + " not found!");
			return;
		}
		s.source.Stop();
	}
}
