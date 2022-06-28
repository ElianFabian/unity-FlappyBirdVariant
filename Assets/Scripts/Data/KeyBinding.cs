using Assets.Scripts.ScriptableObjects.Data;
using UnityEngine;



namespace Assets.Scripts.Data
{
    public class KeyBinding : MonoBehaviour
    {
        public static KeyBindingDataSO keys;

        [SerializeField] KeyBindingDataSO _keyBinding;



        private void Awake()
        {
            keys = _keyBinding;
        }
    }
}
