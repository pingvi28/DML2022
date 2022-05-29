using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJump : MonoBehaviour {

	public LayerMask ground;
    public AudioClip SoundHit;

	private const float jumpForce = 4;

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (LevelController.instance.gameOver)
			return;

		/*if (((1 << other.gameObject.layer) & ground) == 0)
		{
			return;
		}*/

        gameObject.GetComponent<AudioSource>().PlayOneShot(SoundHit);
		// скорость
		rb.velocity = Vector3.zero;
		rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	}

	public void GameOver()
	{
		rb.velocity = Vector3.zero;
		rb.useGravity = false;
	}
}

