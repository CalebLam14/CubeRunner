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
        // SoundPaused = PlayingPaused;
       /* if (PlayingState == true)
        {
            CurrentAudio.UnPause();
        }
        else
        {
            CurrentAudio.Pause();
        }*/
    }
}
