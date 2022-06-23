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

    [SerializeField] KeyCode pauseKey = KeyCode.Escape;

    bool isGamePaused = false;



    private void Awake()
    {
        btnGoToMenu.onClick.AddListener(GoToMenu);
        btnTryAgain.onClick.AddListener(RestartGame);


        // This is in case they're not hidden in the editor.
        HidePauseMenu();
        HideShowGameOverMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey)) HandleGamePause();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnScoreChanged += OnIncrementScore;
        GameManager.Instance.OnGameOver     += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= OnIncrementScore;
        GameManager.Instance.OnGameOver     -= OnGameOver;
    }



    void OnIncrementScore(int newScore)
    {
        txtScore.text = $"Score: {newScore}";
    }

    void OnGameOver()
    {
        Time.timeScale = 0;

        ShowGameOverMenu();
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

    void HandleGamePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            PauseGame();
        }
        else ResumeGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;

        ShowPauseMenu();
    }

    void ResumeGame()
    {
        Time.timeScale = 1;

        HidePauseMenu();
    }

    void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene();

        Time.timeScale = 1;

        SceneManager.LoadSceneAsync(currentScene.name);
    }
}
