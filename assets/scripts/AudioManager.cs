using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource GameOverSound;
	public AudioSource HighScoreSound;

	public void PlayGameOverSound(bool HighScoreExceeded)
	{
		if (HighScoreExceeded == true)
		{
			HighScoreSound.Play();
		}
		else
		{
			GameOverSound.Play();
		}
	}

	public void ChangeSoundPlayingState(bool PlayingPaused)
	{
		// This does nothing for now because I don't
		// have any music made yet.
	}
}
