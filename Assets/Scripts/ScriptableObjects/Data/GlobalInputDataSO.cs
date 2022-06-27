using UnityEngine;



namespace Assets.Scripts.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "GlobalInputData", menuName = "Custom Data/Global Input Data")]
    public class GlobalInputDataSO : ScriptableObject
    {
        public KeyCode pauseKey;
    }
}
