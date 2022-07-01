using UnityEngine.Events;

namespace Assets.Scripts.BaseClasses
{
    public class BaseEventChannelSO<T> : BaseDescriptionSO
    {
        public UnityAction<T> OnEventRaised;

        public void RaiseEvent(T value) => OnEventRaised?.Invoke(value);
    }
}