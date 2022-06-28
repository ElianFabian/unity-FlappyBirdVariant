using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace Assets.Scripts.ScriptableObjects.Data
{
    public class UIBinding : MonoBehaviour
    {
        public TextMeshProUGUI txtScore;

        public Button btnGoToMenu;
        public Button btnTryAgain;

        public RectTransform pauseMenu;
        public RectTransform gameOverMenu;
    }
}
