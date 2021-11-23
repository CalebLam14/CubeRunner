using UnityEngine;

public class DifficultyManager : MonoBehaviour {

	public int StartTarget = 1000;
	int Target;
	public int TargetIncrement = 200;
	public float ForwardAccelerationRate = 100f;
	// public float SidewaysAccelerationRate = 10f;
	public float ObstacleSpaceIncrement = 3f;
	public int MinObstaclesIncrement = 1;
	public int MaxObstaclesIncrement = 1;

	PlayerMovement PlayerMovement;
	SpawnerManager SpawnerManager;

	private void Start()
	{
		PlayerMovement = FindObjectOfType<PlayerMovement>();
		SpawnerManager = FindObjectOfType<SpawnerManager>();

		Target = StartTarget;
	}

	void Update () {
		int CurrentScore = FindObjectOfType<Score>().GetScore();

		if (CurrentScore == Target)
		{
			Target += TargetIncrement;
			PlayerMovement.ForwardForce += ForwardAccelerationRate;
			// PlayerMovement.SidewaysForce += SidewaysAccelerationRate;
			SpawnerManager.Space += ObstacleSpaceIncrement;
			SpawnerManager.MinNumberOfObstacles+= MinObstaclesIncrement;
			SpawnerManager.MaxNumberOfObstacles+= MaxObstaclesIncrement;
		}
	}
}
