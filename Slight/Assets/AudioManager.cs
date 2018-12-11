/// This script handles game audio, it will be used as an engine of sorts.


using UnityEngine.Audio;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour {

    // Public variable where sounds can be added
    public Sound[] sounds;


	// When started, it will load the sounds and set them up for playing with the given parameters
	void Awake () {
		foreach (Sound s in sounds)
        {
            // Add new AudioSource component to this audio engine and initialize it with the given clip
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            // Set the parameters of the new component to those associated with the sound
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
	}
	
	// When run, the Play function will find the given sound and play it
	public void Play (string name) {
        // Find the sound
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Play it
        s.source.Play();
	}
}
