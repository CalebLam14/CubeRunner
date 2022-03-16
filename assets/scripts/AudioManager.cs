using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource GameOverSound;
	public AudioSource HighScoreSound;

	public void PlayGameOverSound(bool highScoreExceeded)
	{
		if (highScoreExceeded)
		{
			HighScoreSound.Play();
		}
		else
		{
			GameOverSound.Play();
		}
	}
}
