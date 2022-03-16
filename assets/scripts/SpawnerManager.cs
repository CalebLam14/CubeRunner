using UnityEngine;

public class SpawnerManager : MonoBehaviour {

	public Transform[] Spawns;

	public int MinNumberOfObstacles;
	public int MaxNumberOfObstacles;

	public Transform Obstacle;
	public Transform SpawnerArea;
	public Transform Player;
	public float ZSpaceBetweenSpawnPoints = 30f;
	public float StartSpawningPositionZ = 100f;

	private void Start()
	{
		// Initialize the spawner
		SpawnerArea.position = new Vector3(0, 0, StartSpawningPositionZ);
	}

	private void Update()
	{
		// Constrain max. and min. number of obstacles
		MaxNumberOfObstacles = Mathf.Clamp(MaxNumberOfObstacles, MinNumberOfObstacles, Spawns.Length);
		MinNumberOfObstacles = Mathf.Clamp(MinNumberOfObstacles, 0, MaxNumberOfObstacles);

        #region Spawn Blocks
        // Obstacles only continue to spawn if the game's state is InProgress in order
        // to save memory
        if (FindObjectOfType<GameManager>().GameState == GameManager.State.InProgress)
		{
			if (SpawnerArea.position.z - Player.position.z <= StartSpawningPositionZ)
			{
				int obstaclesLeft = Random.Range(MinNumberOfObstacles, MaxNumberOfObstacles);

				for (int i = 0; i < Spawns.Length; i++)
				{
					int RandomNum = Random.Range(1, 150);
					if (i == Spawns.Length && ObstaclesLeft != 0 || RandomNum >= 80 && ObstaclesLeft != 0)
					{
						Instantiate(Obstacle, Spawns[i].position, Quaternion.identity);
						obstaclesLeft--;
					}

				}
				SpawnerArea.position += new Vector3(0, 0, ZSpaceBetweenSpawnPoints);
			}
		}
		#endregion
	}
}
