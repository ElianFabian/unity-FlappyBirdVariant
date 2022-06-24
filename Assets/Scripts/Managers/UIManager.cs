﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using NaughtyAttributes;



[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _txtScore;
    [SerializeField] RectTransform   _pauseMenu;
    [SerializeField] RectTransform   _gameOverMenu;
    [SerializeField] Button          _btnGoToMenu;
    [SerializeField] Button          _btnTryAgain;

    [Scene]
    [SerializeField] string _menuSceneName;



    private void Start()
    {
        _btnGoToMenu.onClick.AddListener(GoToMenu);
        _btnTryAgain.onClick.AddListener(GameManager.Instance.RestartGame);

        HidePauseMenu();
        HideShowGameOverMenu();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnScoreChanged += OnScoreChanged;
        GameManager.Instance.OnGameOver     += OnGameOver;
        GameManager.Instance.OnGamePaused   += OnGamePause;
        GameManager.Instance.OnGameResumed  += OnGameResumed;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= OnScoreChanged;
        GameManager.Instance.OnGameOver     -= OnGameOver;
        GameManager.Instance.OnGamePaused   -= OnGamePause;
        GameManager.Instance.OnGameResumed  -= OnGameResumed;
    }



    void OnScoreChanged(int newScore)
    {
        _txtScore.text = $"Score: {newScore}";
    }

    void OnGameOver()
    {
        ShowGameOverMenu();
    }

    void OnGamePause()
    {
        ShowPauseMenu();
    }

    void OnGameResumed()
    {
        HidePauseMenu();
    }

    void GoToMenu()
    {
        GameManager.Instance.ChangeScene(_menuSceneName);
    }

    void ShowPauseMenu()
    {
        _pauseMenu.gameObject.SetActive(true);
        _btnGoToMenu.gameObject.SetActive(true);
    }

    void HidePauseMenu()
    {
        _pauseMenu.gameObject.SetActive(false);
        _btnGoToMenu.gameObject.SetActive(false);
    }

    void ShowGameOverMenu()
    {
        _gameOverMenu.gameObject.SetActive(true);
        _btnGoToMenu.gameObject.SetActive(true);
        _btnTryAgain.gameObject.SetActive(true);
    }

    void HideShowGameOverMenu()
    {
        _gameOverMenu.gameObject.SetActive(false);
        _btnGoToMenu.gameObject.SetActive(false);
        _btnTryAgain.gameObject.SetActive(false);
    }
}
