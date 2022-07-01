using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts.Managers
{
    public class MenuManager : MonoBehaviour
    {
        [Scene]
        [SerializeField] string _chooseYourPlayerScene;



        public void GoToChooseYourSkin()
        {
            SceneManager.LoadSceneAsync(_chooseYourPlayerScene);
        }

        public void ShowHelp()
        {

        }
    }
}
