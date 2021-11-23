using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;
	public Text scoreText;
	public Text BestScoreText;
	public GameManager GameManager;
	int CurrentScore;
	int HighScore;

	public void LoadHighScore()
	{
		string path = Application.persistentDataPath + "/save.dat";

		if (File.Exists(path))
		{
			using FileStream file = File.Open(path, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter();
			PlayerData data = (PlayerData)bf.Deserialize(file);

			HighScore = data.HighScore;
		}
	}

	public void SaveNewHighScore()
	{
		HighScore = CurrentScore;

		using FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);
		BinaryFormatter bf = new BinaryFormatter();
		PlayerData data = new PlayerData();
		data.HighScore = HighScore;

		bf.Serialize(file, data);
		Debug.Log("Player data saved!");
	}

	private void Start()
	{
		LoadHighScore();
		BestScoreText.text = "Best: " + HighScore;
	}

	private void Update()
	{
		if (GameManager.GameState == GameManager.State.InProgress)
		{
			CurrentScore = Mathf.RoundToInt(player.position.z * 0.6f);
			scoreText.text = CurrentScore.ToString("0");

			if (CurrentScore > HighScore)
			{
				GameManager.SetNewRecord();
				BestScoreText.color = new Color(0f/255f, 180f/255f, 15f/255f, 0.8f);
				BestScoreText.text = "Best: " + CurrentScore.ToString("0");
			}
		}    
	}

	public int GetScore ()
	{
		return CurrentScore;
	}
}
