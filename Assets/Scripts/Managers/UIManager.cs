using Assets.Scripts.ScriptableObjects.Data;
using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;



[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    #region Fields

    [SerializeField] UIEventChannelSO   _uiEventChannel;
    [SerializeField] GameEventChannelSO _gameEventChannel;

    [SerializeField] UIBinding _uiBinding;

    #endregion

    #region Unity event functions

    private void Start()
    {
        _uiBinding.btnGoToMenu.onClick.AddListener(_uiEventChannel.RaiseBtnGoToMenu_ClickEvent);
        _uiBinding.btnTryAgain.onClick.AddListener(_uiEventChannel.RaiseBtnTryAgain_ClickEvent);

        HideMouseCursor();
        HidePauseMenu();
        HideGameOverMenu();
    }

    private void OnEnable()
    {
        _gameEventChannel.OnScoreChanged += UpdateScore;
        _gameEventChannel.OnGamePaused   += OnGamePaused;
        _gameEventChannel.OnGameResumed  += OnGameResumed;
        _gameEventChannel.OnGameOver     += OnGameOver;
    }

    private void OnDisable()
    {
        _gameEventChannel.OnScoreChanged -= UpdateScore;
        _gameEventChannel.OnGamePaused   -= OnGamePaused;
        _gameEventChannel.OnGameResumed  -= OnGameResumed;
        _gameEventChannel.OnGameOver     -= OnGameOver;
    }

    #endregion

    #region Event functions

    void OnGamePaused()
    {
        ShowPauseMenu();
        ShowMouseCursor();
    }

    void OnGameResumed()
    {
        HidePauseMenu();
        HideMouseCursor();
    }

    void OnGameOver()
    {
        ShowGameOverMenu();
        ShowMouseCursor();
    }

    #endregion

    #region Methods

    void UpdateScore(int newScore)
    {
        _uiBinding.txtScore.text = $"Score: {newScore}";
    }

    void ShowPauseMenu()
    {
        _uiBinding.pauseMenu.gameObject.SetActive(true);
        _uiBinding.btnGoToMenu.gameObject.SetActive(true);
    }

    void HidePauseMenu()
    {
        _uiBinding.pauseMenu.gameObject.SetActive(false);
        _uiBinding.btnGoToMenu.gameObject.SetActive(false);
    }

    void ShowGameOverMenu()
    {
        _uiBinding.gameOverMenu.gameObject.SetActive(true);
        _uiBinding.btnGoToMenu.gameObject.SetActive(true);
        _uiBinding.btnTryAgain.gameObject.SetActive(true);
    }

    void HideGameOverMenu()
    {
        _uiBinding.gameOverMenu.gameObject.SetActive(false);
        _uiBinding.btnGoToMenu.gameObject.SetActive(false);
        _uiBinding.btnTryAgain.gameObject.SetActive(false);
    }

    void ShowMouseCursor() => Cursor.visible = true;

    void HideMouseCursor() => Cursor.visible = false;

    #endregion
}
