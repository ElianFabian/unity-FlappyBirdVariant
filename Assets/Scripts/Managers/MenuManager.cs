using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts.Managers
{
    public class MenuManager : MonoBehaviour
    {
        [Scene]
        [SerializeField] string _characterSelectionMenuScene;



        public void GoToCharacterSelectionMenu()
        {
            SceneManager.LoadSceneAsync(_characterSelectionMenuScene);
        }

        public void ShowHelp()
        {

        }
    }
}
