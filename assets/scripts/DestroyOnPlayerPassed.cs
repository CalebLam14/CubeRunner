using UnityEngine;

public class DestroyOnPlayerPassed : MonoBehaviour {

	private Transform Player;
	public float Offset = 5f;

	private void Start()
	{
		Player = FindObjectOfType<PlayerMovement>().transform;
	}

	private void FixedUpdate()
	{
		if (Player.position.z >= gameObject.transform.position.z + Offset)
		{
			Destroy(gameObject);
		}
	}

}
