using UnityEngine;
using System;
using Assets.Scripts.PlayerScripts;



namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "PlayerCollisionEventChannel", menuName = "Custom Event Channels/Player Trigger Enter Event Channel")]
    public class PlayerCollisionEventChannelSO : ScriptableObject
    {
        public event Action<Player, Collider2D> OnTriggerEnter2DInDeathZone;
        public event Action<Player, Collider2D> OnTriggerEnter2DScoreZone;

        public void RaiseTriggerEnter2DInDeathZoneEvent(Player player, Collider2D collision)
        {
            OnTriggerEnter2DInDeathZone?.Invoke(player, collision);
        }

        public void RaiseTriggerEnter2DInScoreZoneEvent(Player player, Collider2D collision)
        {
            OnTriggerEnter2DScoreZone?.Invoke(player, collision);
        }
    }
}
