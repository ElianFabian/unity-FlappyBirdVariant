using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "KeyBindingData", menuName = "Custom Data/Key Binding Data")]
    public class KeyBindingDataSO : ScriptableObject
    {
        public KeyCode
            jumpKey,
            pauseKey;
    }
}
