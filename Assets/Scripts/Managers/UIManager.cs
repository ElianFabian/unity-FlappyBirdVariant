using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;



[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    #region Fields

    [SerializeField] TextMeshProUGUI _txtScore;
    [SerializeField] RectTransform   _pauseMenu;
    [SerializeField] RectTransform   _gameOverMenu;
    [SerializeField] Button          _btnGoToMenu;
    [SerializeField] Button          _btnTryAgain;


    public static event Action BtnGoToMenu_Click;
    public static event Action BtnTryAgain_Click;

    #endregion

    #region Unity event functions

    private void Start()
    {
        _btnGoToMenu.onClick.AddListener(BtnGoToMenu_Click.Invoke);
        _btnTryAgain.onClick.AddListener(BtnTryAgain_Click.Invoke);

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

    #endregion

    #region Event functions

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

    #endregion

    #region Methods

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

    #endregion
}
