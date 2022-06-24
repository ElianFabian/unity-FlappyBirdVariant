using UnityEngine;
using Assets.Scripts.PlayerScripts;
using System;



namespace Assets.Scripts.PipeScripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class DeathZone : MonoBehaviour
    {
        public static event Action<Player, Collider2D> OnPlayerCollided;

        BoxCollider2D _boxCollider2D;
        Rigidbody2D   _rigidbody2D;



        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _rigidbody2D   = GetComponent<Rigidbody2D>();


            _boxCollider2D.isTrigger = true;

            _rigidbody2D.isKinematic = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            OnPlayerCollided?.Invoke(player, collision);
        }
    }
}
