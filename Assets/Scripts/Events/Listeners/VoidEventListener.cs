using Assets.Scripts.Events.ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    [Serializable]
    public class VoidEvent : UnityEvent { }


    public class VoidEventListener : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _channel = default;

        public VoidEvent OnEventRaised;

        private void OnEnable()
        {
            if (_channel != null)
                _channel.OnEventRaised += Respond;
        }

        private void OnDisable()
        {
            if (_channel != null)
                _channel.OnEventRaised -= Respond;
        }

        private void Respond()
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke();
        }
    }
}
