using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] RectTransform   pauseMenu;
    [SerializeField] RectTransform   gameOverMenu;
    [SerializeField] Button          btnGoToMenu;
    [SerializeField] Button          btnTryAgain;



    private void Awake()
    {
        btnGoToMenu.onClick.AddListener(GoToMenu);
        btnTryAgain.onClick.AddListener(RestartGame);


        // This is in case they're not hidden in the editor.
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
        txtScore.text = $"Score: {newScore}";
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
        var menuSceneName = "Menu";

        SceneManager.LoadSceneAsync(menuSceneName);
    }

    void ShowPauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
        btnGoToMenu.gameObject.SetActive(true);
    }

    void HidePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        btnGoToMenu.gameObject.SetActive(false);
    }

    void ShowGameOverMenu()
    {
        gameOverMenu.gameObject.SetActive(true);
        btnGoToMenu.gameObject.SetActive(true);
        btnTryAgain.gameObject.SetActive(true);
    }

    void HideShowGameOverMenu()
    {
        gameOverMenu.gameObject.SetActive(false);
        btnGoToMenu.gameObject.SetActive(false);
        btnTryAgain.gameObject.SetActive(false);
    }

    void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene();

        Time.timeScale = 1;

        SceneManager.LoadSceneAsync(currentScene.name);
    }
}
