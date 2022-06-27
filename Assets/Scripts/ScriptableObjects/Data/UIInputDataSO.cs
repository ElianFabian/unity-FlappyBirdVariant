using UnityEngine;



namespace Assets.Scripts.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "UIInputData", menuName = "Custom Data/UI Input Data")]
    public class UIInputDataSO : ScriptableObject
    {
        public KeyCode pauseKey;
    }
}
