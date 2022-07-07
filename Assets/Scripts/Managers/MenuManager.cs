using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts.Managers
{
    public class MenuManager : MonoBehaviour
    {
        [Scene]
        [SerializeField] string _selectCharacterScene;



        public void GoToSelectCharacter()
        {
            SceneManager.LoadSceneAsync(_selectCharacterScene);
        }

        public void ShowHelp()
        {

        }
    }
}
