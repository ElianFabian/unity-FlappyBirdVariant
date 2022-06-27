using UnityEngine;



namespace Assets.Scripts.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "KeyBindingData", menuName = "Custom Data/Key Binding Data")]
    public class KeyBindingDataSo : ScriptableObject
    {
        public KeyCode jumpKey;

        public KeyCode pauseKey;
    }
}
