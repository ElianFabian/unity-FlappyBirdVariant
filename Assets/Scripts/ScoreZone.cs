using Assets.Scripts.PlayerScripts;
using UnityEngine;
using Assets.Scripts.ScriptableObjects.Events;



namespace Assets.Scripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(AudioSource))]
    public class ScoreZone : MonoBehaviour
    {
        [SerializeField] PlayerCollisionEventChannelSO _collisionEventChannel;
        [SerializeField] AudioClip scoreClip;

        BoxCollider2D _boxCollider2D;
        AudioSource   _audioSource;



        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _audioSource   = GetComponent<AudioSource>();

            _boxCollider2D.isTrigger = true;

            _audioSource.playOnAwake = false;
            _audioSource.clip        = scoreClip;
        }

        private void OnEnable()
        {
            _collisionEventChannel.OnCollidedWithScoreZone += OnCollidedWithPlayer;
        }

        private void OnDisable()
        {
            _collisionEventChannel.OnCollidedWithScoreZone -= OnCollidedWithPlayer;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            _collisionEventChannel.RaiseCollidedWithScoreZoneEvent(player, collision);
        }



        void OnCollidedWithPlayer(Player player, Collider2D collision)
        {
            _audioSource.Play();
        }
    }
}
