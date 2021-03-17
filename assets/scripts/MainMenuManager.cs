using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainMenuManager : MonoBehaviour {

    public Text HighScoreText;
    public Text VersionText;
    public GameObject ResetConfirmationMenu;
    public GameObject ButtonsContainer;

    public int LoadHighScore()
    {
        int highScore = 0;
        string path = Application.persistentDataPath + "/save.dat";

        if (File.Exists(path))
        {
            using FileStream file = File.Open(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            PlayerData data = (PlayerData)bf.Deserialize(file);

            highScore = data.HighScore;
        }

        return highScore;
    }

    public void DeleteData()
    {
        string path = Application.persistentDataPath + "/save.dat";
        if (File.Exists(path))
        {
            File.Delete(path);
            UpdateHighScoreDisplay();
        }
    }

    public void ToggleResetConfirmation(bool toggle)
    {
        ResetConfirmationMenu.SetActive(toggle);
    }

    public void ToggleButtons(bool toggle)
    {
        ButtonsContainer.SetActive(toggle);
    }

    private void UpdateHighScoreDisplay()
    {
        HighScoreText.text = "Best: " + LoadHighScore();
    }

    private void DisplayVersion()
    {
        VersionText.text = "v" + Application.version;
    }

    private void Start()
    {
        DisplayVersion();
        UpdateHighScoreDisplay();
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
