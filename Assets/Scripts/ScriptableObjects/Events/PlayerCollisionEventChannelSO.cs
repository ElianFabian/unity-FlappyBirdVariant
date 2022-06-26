using Assets.Scripts.PlayerScripts;
using System;
using UnityEngine;



namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "PlayerCollisionEventChannel", menuName = "Custom Event Channels/Player Trigger Enter Event Channel")]
    public class PlayerCollisionEventChannelSO : ScriptableObject
    {
        public DeathZone deathZone = new();
        public ScoreZone scoreZone = new();
    }

    public class DeathZone
    {
        public event Action<Player, Collider2D> OnTriggerEnter2D;

        public void RaiseTriggerEnter2DEvent(Player player, Collider2D collision)
        {
            OnTriggerEnter2D?.Invoke(player, collision);
        }
    }

    public class ScoreZone
    {
        public event Action<Player, Collider2D> OnTriggerEnter2D;

        public void RaiseTriggerEnter2DEvent(Player player, Collider2D collision)
        {
            OnTriggerEnter2D?.Invoke(player, collision);
        }
    }
}
