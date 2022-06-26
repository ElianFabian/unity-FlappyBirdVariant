using UnityEngine;
using Assets.Scripts.PlayerScripts;
using System;
using Assets.Scripts.ScriptableObjects.Events;



namespace Assets.Scripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] PlayerCollisionEventChannelSO _collisionEventChannel;

        BoxCollider2D _boxCollider2D;



        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();

            _boxCollider2D.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            _collisionEventChannel.RaiseCollidedWithDeathZoneEvent(player, collision);
        }
    }
}
