using System;
using UnityEngine;



namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "PlayerInputEventChannel", menuName = "Custom Event Channels/Player Input Event Channel")]
    public class PlayerInputEventChannelSO : ScriptableObject
    {
        public event Action OnJumpKeyDown;



        public void RaiseJumpKeyPressedEvent() => OnJumpKeyDown?.Invoke();
    }
}
