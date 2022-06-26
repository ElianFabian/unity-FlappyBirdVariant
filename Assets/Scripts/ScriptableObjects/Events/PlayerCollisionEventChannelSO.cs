using UnityEngine;
using System;
using Assets.Scripts.PlayerScripts;



namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "PlayerCollisionEventChannel", menuName = "Custom Event Channels/Player Trigger Enter Event Channel")]
    public class PlayerCollisionEventChannelSO : ScriptableObject
    {
        public event Action<Player, Collider2D> OnTriggerEnter2DWithDeathZone;
        public event Action<Player, Collider2D> OnTriggerEnter2DWithScoreZone;



        public void RaiseTriggerEnter2DWithDeathZoneEvent(Player player, Collider2D collision)
        {
            OnTriggerEnter2DWithDeathZone?.Invoke(player, collision);
        }

        public void RaiseTriggerEnter2DWithScoreZoneEvent(Player player, Collider2D collision)
        {
            OnTriggerEnter2DWithScoreZone?.Invoke(player, collision);
        }
    }
}
