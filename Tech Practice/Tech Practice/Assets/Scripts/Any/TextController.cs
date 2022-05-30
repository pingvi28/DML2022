using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
	public SceneChangeNumder scCh;
	public GameObject[] Text;
	public bool flag = true;

	private void Start()
	{ 
		int count = scCh.sceneChangeCount;

		if (count <= Text.Length) 
		{
			Text[count].gameObject.SetActive(true);
			if (count != 0)
			{
				Text[count - 1].gameObject.SetActive(false);
			}
		}
	}
}
