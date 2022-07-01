using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.BaseClasses
{
    [Serializable]
    public class BaseEvent<T> : UnityEvent<T> { }



    public class BaseEventListener<T> : MonoBehaviour
    {
        [SerializeField] private BaseEventChannelSO<T> _channel = default;

        public BaseEvent<T> OnEventRaised;

        private void OnEnable()
        {
            if (_channel != null) _channel.OnEventRaised += Respond;
        }

        private void OnDisable()
        {
            if (_channel != null) _channel.OnEventRaised -= Respond;
        }

        private void Respond(T value) => OnEventRaised?.Invoke(value);
    }
}