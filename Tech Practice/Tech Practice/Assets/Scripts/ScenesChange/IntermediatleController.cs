using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IntermediatleController : MonoBehaviour
{
	public static IntermediatleController instance;
	public SceneChangeNumder scCh;
	public TextNumber num;
	public Animator animPlay;
	//public Animator animHome;

	private void Awake()
	{
		instance = this;
		animPlay.SetTrigger("Play");
		//animHome.SetTrigger("Home");
	}

	private void Start() 
	{
		num.IncreaseCount();
		scCh.IncreaseScCount();
	}

	public void goToHome()
	{
		SceneManager.LoadScene("MainScene");
	}

	public void ChangeScene() 
	{
		int count = scCh.sceneChangeCount;

		if (count == 1 || count == 4 || count == 6) 
		{
			SceneManager.LoadScene("Intermediate");
		}
		else if (count == 2)
		{
			SceneManager.LoadScene("House Scene");
		}
		else if (count == 3)
		{
			SceneManager.LoadScene("Oven");
		}
		else if (count == 5)
		{
			SceneManager.LoadScene("Swamp");
		}
		else if (count == 7)
		{
			SceneManager.LoadScene("Apple");
		}
		else if (count == 7)
		{
			SceneManager.LoadScene("GameMenu");
		}
	}
}
