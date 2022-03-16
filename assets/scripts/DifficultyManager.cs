using UnityEngine;

public class DifficultyManager : MonoBehaviour {

	public int AccelerationStartTarget = 1000;
	public int AccelerationTargetIncrement = 200;
	public float ForwardAccelerationRate = 100f;
	public float ObstacleSpaceIncrement = 3f;

	public int ObstaclesIncreaseStartTarget = 400;
	public int ObstaclesIncreaseTargetIncrement = 200;
	public int MinObstaclesIncrement = 1;
	public int MaxObstaclesIncrement = 1;

	private int accelerationTarget;
	private int obstaclesIncreaseTarget;

	PlayerMovement PlayerMovement;
	SpawnerManager SpawnerManager;

	private void Start()
	{
		PlayerMovement = FindObjectOfType<PlayerMovement>();
		SpawnerManager = FindObjectOfType<SpawnerManager>();

		accelerationTarget = AccelerationStartTarget;
		obstaclesIncreaseTarget = ObstaclesIncreaseStartTarget;
	}

	void Update () {
		int CurrentScore = FindObjectOfType<Score>().GetScore();

		if (CurrentScore >= accelerationTarget)
		{
			accelerationTarget += AccelerationTargetIncrement;
			PlayerMovement.ForwardForce += ForwardAccelerationRate;
			SpawnerManager.ZSpaceBetweenSpawnPoints += ObstacleSpaceIncrement;
		}

		if (CurrentScore >= obstaclesIncreaseTarget)
        {
			obstaclesIncreaseTarget += ObstaclesIncreaseTargetIncrement;
			SpawnerManager.MinNumberOfObstacles += MinObstaclesIncrement;
			SpawnerManager.MaxNumberOfObstacles += MaxObstaclesIncrement;
		}
	}
}
