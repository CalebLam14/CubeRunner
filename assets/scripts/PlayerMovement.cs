using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody RigidBody;

	public float ForwardForce = 2000f;
	public float MaxForwardForce = 3500f;
	public float HorMoveTime = 0.2f;

	public float StartPosX = 1f;
	public float MoveInterval = 2f;
	public float MinX = -9f;
	public float MaxX = 9f;

	private float inputX = 0f;
    private float moveXMult = 0f;

	private bool isMovingHorizontally = false;

    private void Start()
	{
		transform.position = new Vector3(StartPosX, 1f, 0f);
	}

    private void Update()
	{
		inputX = (Input.GetButtonDown("Horizontal") == true) ? Input.GetAxisRaw("Horizontal") : 0f;
		moveXMult = (inputX > 0) ? 1f : (inputX < 0) ? -1f : 0f;
		StartCoroutine(MoveX(MoveInterval * moveXMult));
	}

	private void FixedUpdate()
	{
		RigidBody.AddForce(0f, 0f, Mathf.Clamp(ForwardForce, 0f, MaxForwardForce) * Time.deltaTime);
	}

	private IEnumerator MoveX(float moveByX)
	{
		if (moveByX != 0f && !isMovingHorizontally)
		{
			isMovingHorizontally = true;
			float t = 0f;
			float originalX = RigidBody.position.x;
            while (t <= 1f)
			{
                Vector3 pos = RigidBody.position;
                t += Time.deltaTime / HorMoveTime;

				// Calculate the x to get to with sine easing.
				float newX = Mathf.Clamp(originalX +
					(moveByX * Mathf.Sin(Mathf.Lerp(0f, 1f, t) * Mathf.PI / 2f)),
					MinX, MaxX);

				RigidBody.MovePosition(new Vector3(newX, pos.y, pos.z));

				if (1f - t <= 0.15f && isMovingHorizontally)
				{
					isMovingHorizontally = false;
				}

				yield return null;
			}
		}
	}
}