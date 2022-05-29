using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public static LevelController instance;

	public GameObject gameOverPanel;
	public bool gameOver;
	public SceneChangeNumder scCh;
	public TextNumber text;

	private void Awake()
	{
		instance = this;
	}

	public void GameOver()
	{
        if (gameOverPanel != null) gameOverPanel.SetActive(true);

		gameOver = true;
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void goToHome()
	{
		// при возращении уменьшаем число
		scCh.ReduseScCount();
		text.RuduseCount();
		SceneManager.LoadScene("MainScene");
	}
}

