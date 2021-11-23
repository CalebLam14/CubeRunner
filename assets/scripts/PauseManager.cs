using UnityEngine;
// using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

	public GameObject PauseMenu;
	public GameObject MainPauseMenu;
	public GameObject ConfirmQuitMenu;
	bool Paused = false;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Paused = !Paused;
			SetPause(Paused);
		}
	}

	public void SetPause(bool PausedState)
	{
		FindObjectOfType<AudioManager>().ChangeSoundPlayingState(PausedState);
		ConfirmQuitMenu.SetActive(false);
		PauseMenu.SetActive(PausedState);
		if (PausedState == true)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
			Paused = false;
		}
	}

	public void ShowConfirmQuitMenu()
	{
		ConfirmQuitMenu.SetActive(true);
		MainPauseMenu.SetActive(false);
	}

	public void ShowMainPauseMenu()
	{
		ConfirmQuitMenu.SetActive(false);
		MainPauseMenu.SetActive(true);
	}
}
