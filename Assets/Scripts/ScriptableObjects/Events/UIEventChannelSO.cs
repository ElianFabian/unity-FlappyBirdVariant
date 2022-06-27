using System;
using UnityEngine;



namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "UIEventChannel", menuName = "Custom Event Channels/UI Event Channel")]
    public class UIEventChannelSO : ScriptableObject
    {
        public event Action BtnGoToMenu_Click;
        public event Action BtnTryAgain_Click;
        public event Action OnPauseToggled;



        public void RaiseBtnGoToMenu_ClickEvent() => BtnGoToMenu_Click?.Invoke();
        public void RaiseBtnTryAgain_ClickEvent() => BtnTryAgain_Click?.Invoke();
        public void ReaiseTogglePauseEvent() => OnPauseToggled?.Invoke();
    }
}
