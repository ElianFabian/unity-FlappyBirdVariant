using Assets.Scripts.PlayerScripts;
using UnityEngine;
using System;



namespace Assets.Scripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class ScoreZone : MonoBehaviour
    {
        public static event Action<Player, Collider2D> OnPlayerCollided;

        BoxCollider2D _boxCollider2D;



        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();

            _boxCollider2D.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            OnPlayerCollided?.Invoke(player, collision);

            Destroy(gameObject);
        }
    }
}
