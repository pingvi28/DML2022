using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public CapsMovement movement;
	public RoadGenerator road;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Obstacle"))
		{
			road.speedRoad = 0.2f;
			movement.enabled = false;   // оставливает игрока
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
