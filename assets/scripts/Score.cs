using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;
	public Text ScoreText;
	public Text BestScoreText;
	public GameManager GameManager;
	private int currentScore;
	private int highScore;

	private void Start()
	{
		LoadHighScore();
		BestScoreText.text = "Best: " + highScore;
		startTimestamp = Time.timeSinceLevelLoad;
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
