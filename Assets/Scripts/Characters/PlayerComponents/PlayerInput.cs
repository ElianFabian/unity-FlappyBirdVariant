using Assets.Scripts.Data.ScriptableObjects;
using Assets.Scripts.Events.ScriptableObjects;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] KeyDataSO _keyData;

        public VoidEventChannelSO _onJump;

        IPlayerAction _action;
        IPlayerAudio _audio;



        private void Awake()
        {
            _action = GetComponent<IPlayerAction>();
            _audio  = GetComponent<IPlayerAudio>();
        }



        public void HandleInput()
        {
            if (Input.GetKeyDown(_keyData.jumpKey))
            {
                _action.Jump();
                _audio.PlayJumpSound();
                _onJump.RaiseEvent();
            }
        }
    }
}
