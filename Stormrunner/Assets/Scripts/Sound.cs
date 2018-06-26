﻿using UnityEngine;
using UnityEngine.Audio;

//Sound class
[System.Serializable]
public class Sound {

	public string name;

	public AudioClip clip;

	[Range(0f,1f)]
	public float volume;

	[Range(.1f,3f)]
	public float pitch;

	[HideInInspector]
	public AudioSource source;

	public bool loop;

	public AudioMixerGroup mixer;


}
