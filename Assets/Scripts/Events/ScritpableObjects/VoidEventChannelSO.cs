using Assets.Scripts.BaseClasses;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Events/Void Event Channel")]
    public class VoidEventChannelSO : BaseDescriptionSO
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent() => OnEventRaised?.Invoke();
    }
}
