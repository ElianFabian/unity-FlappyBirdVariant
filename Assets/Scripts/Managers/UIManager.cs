using Assets.Scripts.ScriptableObjects.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    #region Fields

    [SerializeField] UIEventChannelSO   _uiEventChannel;
    [SerializeField] GameEventChannelSO _gameEventChannel;

    [SerializeField] TextMeshProUGUI _txtScore;
    [SerializeField] RectTransform   _pauseMenu;
    [SerializeField] RectTransform   _gameOverMenu;
    [SerializeField] Button          _btnGoToMenu;
    [SerializeField] Button          _btnTryAgain;

    #endregion

    #region Unity event functions

    private void Start()
    {
        _btnGoToMenu.onClick.AddListener(_uiEventChannel.RaiseBtnGoToMenu_ClickEvent);
        _btnTryAgain.onClick.AddListener(_uiEventChannel.RaiseBtnTryAgain_ClickEvent);

        HidePauseMenu();
        HideShowGameOverMenu();
    }

    private void OnEnable()
    {
        _gameEventChannel.OnScoreChanged += OnScoreChanged;
        _gameEventChannel.OnGameOver     += OnGameOver;
        _gameEventChannel.OnGamePaused   += OnGamePause;
        _gameEventChannel.OnGameResumed  += OnGameResumed;
    }

    private void OnDisable()
    {
        _gameEventChannel.OnScoreChanged -= OnScoreChanged;
        _gameEventChannel.OnGameOver     -= OnGameOver;
        _gameEventChannel.OnGamePaused   -= OnGamePause;
        _gameEventChannel.OnGameResumed  -= OnGameResumed;
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
