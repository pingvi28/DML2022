using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	public Text scoreText;
	public static int score;

	void Update () {
		scoreText.text = score.ToString("0");
	}
}

