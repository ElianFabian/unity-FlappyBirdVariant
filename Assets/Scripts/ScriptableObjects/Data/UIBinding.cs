using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace Assets.Scripts.ScriptableObjects.Data
{
    // Used as alternative to Scriptable Objects because there's no way to
    // reference GameObjects from the scene using them.
    public class UIBinding : MonoBehaviour
    {
        public TextMeshProUGUI txtScore;

        public Button btnGoToMenu;
        public Button btnTryAgain;

        public RectTransform pauseMenu;
        public RectTransform gameOverMenu;
    }
}
