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
        [SerializeField] PlayerCollisionEventChannelSO _playerCollisionEventChannel;
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            // This avoids the player to increase the score more than once
            _boxCollider2D.enabled = false;

            _audioSource.Play();

            _playerCollisionEventChannel.scoreZone.RaiseTriggerEnter2DEvent(player, collision);
        }
    }
}
