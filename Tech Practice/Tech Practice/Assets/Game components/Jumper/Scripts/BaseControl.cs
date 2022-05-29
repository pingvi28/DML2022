using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour {

	public float speed = 9;
	public float offsetMove = -32;
	public Transform[] cylinders;

	bool swipe = false;
	float startXPos = 0;

	void Start () 
	{
		RandomRotation();
	}
	
	void Update () 
	{
		if (LevelController.instance.gameOver)
			return;

		Rotate();
	}

	void Rotate()
	{
		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{

			if (Input.touchCount == 1)
			{
				// проверка нажатия мышки
				if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary)
				{
					startXPos = Input.GetAxis("Mouse X");
					swipe = true;
				}
				else if (Input.GetTouch(0).phase == TouchPhase.Ended)
				{
					swipe = false;
				}

				// если зажата -> крутим
				if (swipe)
				{
					transform.Rotate(new Vector3(0, (Input.GetAxis("Mouse X") - startXPos) * -1, 0) * speed * Time.deltaTime);
				}
			}
		}
		else
		{
			if (Input.GetMouseButton(0))
			{
				transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * -1, 0) * speed * Time.deltaTime);
			}
		}	
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Reposition(offsetMove);
			RandomRotation();
		}
	}

	void RandomRotation()
	{
		for (int i = 0; i < cylinders.Length; i++)
		{
			cylinders[i].rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
		}
	}

	public void Reposition(float yPos)
	{
		transform.position = new Vector3(transform.position.x, transform.position.y + yPos, transform.position.z);
	}
}

