using Assets.Scripts.Data.ScriptableObjects;
using Assets.Scripts.Events.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
{
    public class PlayerInput : BasePlayerComponent
    {
        [SerializeField] KeyDataSO _keyData;

        public VoidEventChannelSO _onJump;



        public void HandleInput()
        {
            if (Input.GetKeyDown(_keyData.jumpKey)) _onJump.RaiseEvent();
        }
    }
}
