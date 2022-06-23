using UnityEngine;
using TMPro;



[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtScore;

    private void OnEnable()
    {
        GameManager.Instance.OnIncrementScore += OnIncrementScore;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnIncrementScore -= OnIncrementScore;
    }

    void OnIncrementScore(int newScore)
    {
        txtScore.text = $"Score: {newScore}";
    }
}
