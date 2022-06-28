using Assets.Scripts.EventChannels;
using Assets.Scripts.PlayerScripts;
using UnityEngine;



namespace Assets.Scripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class DeathZone : MonoBehaviour
    {
        BoxCollider2D _boxCollider2D;



        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();

            _boxCollider2D.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            PlayerCollisionEvents.RaiseDeathZoneTriggerEnter2DEvent(player, collision);
        }
    }
}
