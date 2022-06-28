using Assets.Scripts.EventChannels;
using Assets.Scripts.ScriptableObjects.Data;
using UnityEngine;



[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    #region Fields

    [SerializeField] UIBinding _uiBinding;

    #endregion

    #region Unity event functions

    private void Start()
    {
        _uiBinding.btnGoToMenu.onClick.AddListener(UIEvents.RaiseBtnGoToMenu_ClickEvent);
        _uiBinding.btnTryAgain.onClick.AddListener(UIEvents.RaiseBtnTryAgain_ClickEvent);

        HideMouseCursor();
        HidePauseMenu();
        HideGameOverMenu();
    }

    private void OnEnable()
    {
        GameEvents.OnScoreChanged += UpdateScore;
        GameEvents.OnGamePaused   += OnGamePaused;
        GameEvents.OnGameResumed  += OnGameResumed;
        GameEvents.OnGameOver     += OnGameOver;
    }

    private void OnDisable()
    {
        GameEvents.OnScoreChanged -= UpdateScore;
        GameEvents.OnGamePaused   -= OnGamePaused;
        GameEvents.OnGameResumed  -= OnGameResumed;
        GameEvents.OnGameOver     -= OnGameOver;
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
        _uiBinding.txtScore.SetText($"Score: {newScore}");
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
