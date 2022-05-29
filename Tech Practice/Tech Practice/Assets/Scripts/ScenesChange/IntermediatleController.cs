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
	public Animator animHome;

	private void Awake()
	{
		instance = this;
		animPlay.SetTrigger("Play");
		animHome.SetTrigger("Home");
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

		if (count == 1 || count == 3 || count == 5) 
		{
			SceneManager.LoadScene("MainScene");
		}
		else if (count == 2)		{
			SceneManager.LoadScene("Jumping");
		}
		else if (count == 4)
		{
			SceneManager.LoadScene("CapsGame");
		}
	}
}
