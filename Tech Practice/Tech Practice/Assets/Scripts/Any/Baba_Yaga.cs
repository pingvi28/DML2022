using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baba_Yaga : MonoBehaviour
{

	public AudioClip SoundHit;
	private void OnTriggerEnter(Collider other)
	{
		gameObject.GetComponent<AudioSource>().PlayOneShot(SoundHit);
	}
}

