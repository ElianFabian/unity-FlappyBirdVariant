using UnityEngine;



namespace Assets.Scripts.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "PlayerInputData", menuName = "Custom Data/Player Input Data")]
    public class PlayerInputDataSO : ScriptableObject
    {
        public KeyCode jumpKey;
    }
}
