using UnityEngine;



class AudioManager : MonoBehaviour
{
    private void Start()
    {
        ResumeAudio();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGamePaused  += OnGamePaused;
        GameManager.Instance.OnGameResumed += OnGameResumed;
        GameManager.Instance.OnGameOver    += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGamePaused  -= OnGamePaused;
        GameManager.Instance.OnGameResumed -= OnGameResumed;
        GameManager.Instance.OnGameOver    -= OnGameOver;
    }



    void OnGamePaused()
    {
        PauseAudio();
    }

    void OnGameResumed()
    {
        ResumeAudio();
    }

    void OnGameOver()
    {
        PauseAudio();
    }


    void PauseAudio()
    {
        AudioListener.pause = true;
    }

    void ResumeAudio()
    {
        AudioListener.pause = false;
    }
}
