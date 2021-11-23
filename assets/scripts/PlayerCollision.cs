using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement Movement;
	public Rigidbody PlayerRigidBody;

	void OnCollisionEnter(Collision CollisionInfo)
	{
		if (CollisionInfo.collider.tag == "Obstacle")
		{ // Player hit an obstacle.
			Movement.enabled = false;
			FindObjectOfType<GameManager>().EndGame();
			PlayerRigidBody.constraints = RigidbodyConstraints.None;
			PlayerRigidBody.AddTorque(new Vector3(Random.Range(10f, 20f), Random.Range(10f, 20f), Random.Range(10f, 20f)), ForceMode.Impulse);
			PlayerRigidBody.AddForce(Random.Range(-10f, 10f), 50f, -50f, ForceMode.Impulse);
		}
	}

	private void Update()
	{
		if (PlayerRigidBody.position.y < 0.75f)
		{
			FindObjectOfType<PlayerMovement>().enabled = false;
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
