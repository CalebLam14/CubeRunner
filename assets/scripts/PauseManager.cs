using UnityEngine;
// using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

	public GameObject PauseMenu;
	public GameObject MainPauseMenu;
	public GameObject ConfirmQuitMenu;
	private bool paused = false;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;
			SetPause(paused);
		}
	}

	public void SetPause(bool pausedState)
	{
		ConfirmQuitMenu.SetActive(false);
		PauseMenu.SetActive(pausedState);
		if (pausedState == true)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
			paused = false;
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
