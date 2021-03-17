using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    public enum State { InProgress, GameOver };

    bool GameHasEnded = false;
    public Text GameOverText;
    public State GameState = State.InProgress;
    private bool NewRecord = false;
    public GameObject PlayAgainMenu;
    //public Text EscapeText;
    public string HighScoreDataKey = "BestScore";
    

    private void Start()
    {
        GameState = State.InProgress;
    }

    public void EndGame ()
    
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            GameState = State.GameOver;
            if (NewRecord == true)
            {
                GameOverText.color = new Color(0f/255f, 180f/255f, 15f/255f);
                GameOverText.text = "NEW RECORD!";
                FindObjectOfType<Score>().SaveNewHighScore();
            }
            FindObjectOfType<AudioManager>().PlayGameOverSound(NewRecord);
            GameOverText.gameObject.SetActive(true);
            PlayAgainMenu.SetActive(true);
            FindObjectOfType<PauseManager>().gameObject.SetActive(false);
        }
    }

    public void ResetLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu ()
    {
        /*int CurrentScore = FindObjectOfType<Score>().GetScore();

        if (CurrentScore > PlayerPrefs.GetInt(HighScoreDataKey, 0))
        {
            PlayerPrefs.SetInt(HighScoreDataKey, CurrentScore);
        }*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }

    public void SetNewRecord()
    {
        NewRecord = true;
    }
}