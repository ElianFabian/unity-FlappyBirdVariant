using Assets.Scripts.PlayerScripts;
using System;
using UnityEngine;



namespace Assets.Scripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class DeathZone : MonoBehaviour
    {
        public static event Action<Player, Collider2D> OnPlayerTriggerEnter2D;

        BoxCollider2D _boxCollider2D;



        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();

            _boxCollider2D.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            OnPlayerTriggerEnter2D?.Invoke(player, collision);
        }
    }
}
