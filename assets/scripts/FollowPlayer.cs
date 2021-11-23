using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform Player;
    public float startingPositionZOffset = -10f;
	// Update is called once per frame
	void Update () {
		float playerPositionZ = Player.position.z;
		float offset = gameObject.transform.lossyScale.z / 2f + startingPositionZOffset;
		gameObject.transform.position = new Vector3(0, 0, playerPositionZ + offset);
	}
}
