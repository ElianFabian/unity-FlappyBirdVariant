using Assets.Scripts.BaseClasses;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Events/Int Event Channel")]
    public class IntEventChannelSO : BaseEventChannelSO<SingleValue<int>> { }
}