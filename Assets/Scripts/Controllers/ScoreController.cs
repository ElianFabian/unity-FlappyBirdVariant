using Assets.Scripts.Data;
using Assets.Scripts.Data.ScriptableObjects;
using Assets.Scripts.Events.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] IntVariableSO _score;

        [SerializeField] IntEventChannelSO _onScoreChanged;

        TextMeshProUGUI _txtScore;



        private void Awake()
        {
            _txtScore = GetComponent<TextMeshProUGUI>();
        }



        public void UpdateScore()
        {
            _score.value++;

            SingleValue<int> newScore;
            newScore.value = _score.value;

            _txtScore.SetText($"Score: {_score.value}");

            _onScoreChanged.RaiseEvent(newScore);
        }

        public void RestartScore()
        {
            _score.value = _score.initialValue;
        }
    }
}