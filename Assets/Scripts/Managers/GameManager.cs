using Assets.Scripts.Util;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;



[DisallowMultipleComponent]
public class GameManager : SingletonPersistent<GameManager>
{
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;

    public event Action         OnGameOver;
    public event Action         OnGamePaused;
    public event Action         OnGameResumed;
    public event Action         OnGameRestarted;
    public event Action<string> OnSceneChanged;
    public event Action<int>    OnScoreChanged;

    int score = 0;
    bool isGamePaused = false;



    private void OnEnable()
    {
        OnGameOver -= SetGameOver;
    }

    private void OnDisable()
    {
        OnGameOver -= SetGameOver;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(pauseKey)) return;

        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Pause();
            OnGamePaused?.Invoke();
        }
        else
        {
            Resume();
            OnGameResumed?.Invoke();
        }
    }

    public void IncrementScore()
    {
        score++;

        OnScoreChanged?.Invoke(score);
    }

    public void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadSceneAsync(currentScene.name);

        Resume();

        OnGameRestarted?.Invoke();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);

        OnSceneChanged?.Invoke(sceneName);
    }

    void ResetScore()
    {
        score = 0;
    }

    public void SetGameOver()
    {
        Pause();
        ResetScore();

        OnGameOver?.Invoke();
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void Resume()
    {
        Time.timeScale = 1;
    }
}
