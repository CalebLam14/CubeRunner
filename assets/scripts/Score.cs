using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;
	public Text ScoreText;
	public Text BestScoreText;
	public GameManager GameManager;
	public float ScorePerSecond;
	private int currentScore;
	private int highScore;
	private float startTimestamp;

	private void Start()
	{
		LoadHighScore();
		BestScoreText.text = "Best: " + highScore;
		startTimestamp = Time.timeSinceLevelLoad;
	}

	private void Update()
	{
		if (GameManager.GameState == GameManager.State.InProgress)
		{
			float timeElapsed = Time.timeSinceLevelLoad - startTimestamp;
			currentScore = Mathf.RoundToInt(timeElapsed * ScorePerSecond);
			ScoreText.text = currentScore.ToString("0");

			if (currentScore > highScore)
			{
				GameManager.SetNewRecord();
				BestScoreText.color = new Color(0f/255f, 180f/255f, 15f/255f, 0.8f);
				BestScoreText.text = "Best: " + currentScore.ToString("0");
			}
		}    
	}

	public void LoadHighScore()
	{
		string path = Application.persistentDataPath + "/save.dat";

		if (File.Exists(path))
		{
			using FileStream file = File.Open(path, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter();
			PlayerData data = (PlayerData)bf.Deserialize(file);

			highScore = data.HighScore;
		}
	}

	public void SaveNewHighScore()
	{
		highScore = currentScore;

		using FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);
		BinaryFormatter bf = new BinaryFormatter();
		PlayerData data = new PlayerData();
		data.HighScore = highScore;

		bf.Serialize(file, data);
		Debug.Log("Player data saved!");
	}

	public int GetScore()
	{
		return currentScore;
	}
}
