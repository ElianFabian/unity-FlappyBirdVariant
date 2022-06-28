using Assets.Scripts.EventChannels;
using Assets.Scripts.PlayerScripts;
using UnityEngine;



namespace Assets.Scripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(AudioSource))]
    public class ScoreZone : MonoBehaviour
    {
        [SerializeField] AudioClip _scoreClip;

        BoxCollider2D _boxCollider2D;
        AudioSource   _audioSource;



        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _audioSource   = GetComponent<AudioSource>();

            _boxCollider2D.isTrigger = true;

            _audioSource.playOnAwake = false;
            _audioSource.clip        = _scoreClip;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            // This avoids the player to increase the score more than once
            _boxCollider2D.enabled = false;

            _audioSource.Play();

            PlayerCollisionEvents.RaiseScoreZoneTriggerEnter2DEvent(player, collision);
        }
    }
}
