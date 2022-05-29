using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	private bool paused = false;
	public GameObject plane;
	public GameObject pause;

	public void PutPause()
	{
		if (!paused)
		{
			Time.timeScale = 0;
			paused = true;
			pause.SetActive(true);
			plane.SetActive(true);
		}
	}
	public void Run()
	{
		if (paused)
		{
			Time.timeScale = 1;
			paused = false;
			pause.SetActive(false);
			plane.SetActive(false);
		}
	}
}