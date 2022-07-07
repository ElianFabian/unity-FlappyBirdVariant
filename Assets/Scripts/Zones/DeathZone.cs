using Assets.Scripts.Characters.PlayerComponents;
using Assets.Scripts.Events.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Zones
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] Collider2DEventChannelSO _onPlayerCollided;

        BoxCollider2D _boxCollider2D;



        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();

            _boxCollider2D.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            _onPlayerCollided.RaiseEvent(collision);
        }
    }
}
