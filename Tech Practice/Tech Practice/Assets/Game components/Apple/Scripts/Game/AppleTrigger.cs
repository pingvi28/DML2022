using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Score.score++;
			gameObject.SetActive(false);
		}
	}
}

