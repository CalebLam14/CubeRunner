using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    public Transform[] Spawns;
    public int MinNumberOfObstacles;
    public int MaxNumberOfObstacles;
    public Transform Obstacle;
    public Transform SpawnerArea;
    public Transform Player;
    public float Space = 30f;
    public float StartSpawningPositionZ = 100f;

    private void Start()
    {
        MinNumberOfObstacles = Mathf.Clamp(MinNumberOfObstacles, 0, 5);
        MaxNumberOfObstacles = Mathf.Clamp(MaxNumberOfObstacles, 3, 7);
        SpawnerArea.position = new Vector3(0, 0, StartSpawningPositionZ);
    }

    private void Update()
    {
        #region Spawn Blocks
        if (FindObjectOfType<GameManager>().GameState == GameManager.State.InProgress)
        {
            if (SpawnerArea.position.z - Player.position.z <= StartSpawningPositionZ)
            {
                int ObstaclesLeft = Random.Range(MinNumberOfObstacles, MaxNumberOfObstacles);

                for (int i = 0; i < Spawns.Length; i++)
                {
                    int RandomNum = Random.Range(1, 150);
                    if (i == Spawns.Length && ObstaclesLeft != 0 || RandomNum >= 80 && ObstaclesLeft != 0)
                    {
                        Instantiate(Obstacle, Spawns[i].position, Quaternion.identity);
                        ObstaclesLeft--;
                    }

                }
                SpawnerArea.position += new Vector3(0, 0, Space);
            }
        }
        #endregion


    }
}
