using System;
using UnityEngine;



namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "PlayerActionEventChannel", menuName = "Custom Event Channels/Player Action Event Channel")]
    public class PlayerActionEventChannelSO : ScriptableObject
    {
        public event Action OnJump;



        public void RaiseJumpEvent() => OnJump?.Invoke();
    }
}
