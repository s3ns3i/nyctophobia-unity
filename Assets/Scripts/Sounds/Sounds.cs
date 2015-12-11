using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

	[SerializeField]
	int soundToPlay;
	[SerializeField]
	float volumeScale;
	[SerializeField]
	AudioClip[] sounds;
	AudioSource audioSource;

	public void PlaySound()
	{
		audioSource = GetComponent<AudioSource>();
		if (soundToPlay >= 0)
			audioSource.PlayOneShot(sounds[soundToPlay], volumeScale);
	}

	public void PlaySound (int soundToPlay, float volumeScale) {
		audioSource = GetComponent<AudioSource>();
		if(soundToPlay >= 0)
		audioSource.PlayOneShot(sounds[soundToPlay], volumeScale);
	}
}
