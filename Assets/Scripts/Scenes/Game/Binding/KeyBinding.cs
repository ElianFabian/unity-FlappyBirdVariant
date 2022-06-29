using Assets.Scripts.Scenes.Game.ScriptableObjects.Data;
using UnityEngine;

namespace Assets.Scripts.Scenes.Game.Binding
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
