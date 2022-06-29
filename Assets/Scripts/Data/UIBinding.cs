using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace Assets.Scripts.ScriptableObjects.Data
{
    [DisallowMultipleComponent]
    public class UIBinding : MonoBehaviour
    {
        public static UIBinding instance;

        public TextMeshProUGUI txtScore;

        public Button btnGoToMenu;
        public Button btnTryAgain;

        public RectTransform pauseMenu;
        public RectTransform gameOverMenu;



        private void Awake()
        {
            instance = this;
        }
    }
}
