using Assets.Scripts.ScriptableObjects.Data;
using System;
using UnityEngine;



namespace Assets.Scripts.Managers.Game
{
    [DisallowMultipleComponent]
    public class UIManager : MonoBehaviour
    {
        #region Fields

        public static event Action
            BtnGoToMenu_Click,
            BtnTryAgain_Click;

        UIGameBinding _uiBinding;

        #endregion

        #region Unity event functions

        private void Start()
        {
            _uiBinding = UIGameBinding.instance;

            _uiBinding.btnGoToMenu.onClick.AddListener(BtnGoToMenu_Click.Invoke);
            _uiBinding.btnTryAgain.onClick.AddListener(BtnTryAgain_Click.Invoke);

            HideMouseCursor();
            HidePauseMenu();
            HideGameOverMenu();
        }

        private void OnEnable()
        {
            GameManager.OnScoreChanged += UpdateScore;
            GameManager.OnGamePaused   += OnGamePaused;
            GameManager.OnGameResumed  += OnGameResumed;
            GameManager.OnGameOver     += OnGameOver;
        }

        private void OnDisable()
        {
            GameManager.OnScoreChanged -= UpdateScore;
            GameManager.OnGamePaused   -= OnGamePaused;
            GameManager.OnGameResumed  -= OnGameResumed;
            GameManager.OnGameOver     -= OnGameOver;
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
}
