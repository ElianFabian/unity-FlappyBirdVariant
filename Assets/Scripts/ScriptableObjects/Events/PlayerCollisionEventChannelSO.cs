using UnityEngine;
using System;
using Assets.Scripts.PlayerScripts;



namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "PlayerCollisionEventChannel", menuName = "Custom Event Channels/Player Collision Event Channel")]
    public class PlayerCollisionEventChannelSO : ScriptableObject
    {
        public event Action<Player, Collider2D> OnCollidedWithDeathZone;
        public event Action<Player, Collider2D> OnCollidedWithScoreZone;

        public void RaiseCollidedWithDeathZoneEvent(Player player, Collider2D collision)
        {
            OnCollidedWithDeathZone?.Invoke(player, collision);
        }

        public void RaiseCollidedWithScoreZoneEvent(Player player, Collider2D collision)
        {
            OnCollidedWithScoreZone?.Invoke(player, collision);
        }
    }
}
