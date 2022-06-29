using Assets.Scripts.ScriptableObjects.Data;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    [Scene]
    [SerializeField] string _chooseYourPlayerScene;

    UIMainMenuBinding _menuBinding;



    private void Start()
    {
        _menuBinding = UIMainMenuBinding.instance;

        _menuBinding.btnChooseYourSkin.onClick.AddListener(GoToChooseYourSkin);
        _menuBinding.btnHelp.onClick.AddListener(ShowHelp);
    }


    void GoToChooseYourSkin()
    {
        SceneManager.LoadSceneAsync(_chooseYourPlayerScene);
    }

    void ShowHelp()
    {

    }
}
