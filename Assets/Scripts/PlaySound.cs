using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
	public AudioClip soundToPlay = null;
	public AudioSource audioSource = null;
	
	private void OnTriggerEnter(Collider other)
	{
		if (audioSource.isPlaying)
			audioSource.Stop();

		audioSource.clip = soundToPlay;
		audioSource.Play();
	}
}
