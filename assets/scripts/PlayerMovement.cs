using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody RigidBody;

    public float ForwardForce = 2000f;
    public float MaxForwardForce = 3500f;
    public float HorMoveTime = 0.2f;

    public float startPosX = 1f;

    private float inputX = 0f;
    private float moveXMult = 0f;

    private bool isMovingHorizontally = false;

    private void Start()
    {
        transform.position = new Vector3(startPosX, 1f, 0f);
    }

    private void Update()
    {
        inputX = (Input.GetButtonDown("Horizontal") == true) ? Input.GetAxisRaw("Horizontal") : 0f;
        moveXMult = (inputX > 0) ? 1f : (inputX < 0) ? -1f : 0f;
        StartCoroutine(moveX(2f * moveXMult));
    }

    private void FixedUpdate()
    {
        RigidBody.AddForce(0f, 0f, Mathf.Clamp(ForwardForce, 0f, MaxForwardForce) * Time.deltaTime);
        // RigidBody.MovePosition(RigidBody.position + new Vector3(2f * moveXMult, 0, 0));

        // RigidBody.AddForce(Input.GetAxisRaw("Horizontal") * SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    private IEnumerator moveX(float moveByX)
    {
        if (moveByX != 0f && !isMovingHorizontally)
        {
            isMovingHorizontally = true;
            float t = 0f;
            float originalX = RigidBody.position.x;
            Vector3 pos = RigidBody.position;
            while (t <= 1f)
            {
                pos = RigidBody.position;
                t += Time.deltaTime / HorMoveTime;
                // RigidBody.MovePosition(new Vector3(originalX + Mathf.Lerp(0f, moveByX, t), pos.y, pos.z));
                RigidBody.MovePosition(new Vector3(originalX + (moveByX * Mathf.Sin(Mathf.Lerp(0f, 0.5f, t) * Mathf.PI)), pos.y, pos.z));

                if (1f - t <= 0.15f && isMovingHorizontally == true)
                {
                    isMovingHorizontally = false;
                }

                yield return null;
            }
        }
    }
}