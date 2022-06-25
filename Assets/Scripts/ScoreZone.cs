using Assets.Scripts.PlayerScripts;
using UnityEngine;
using System;



namespace Assets.Scripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(AudioSource))]
    public class ScoreZone : MonoBehaviour
    {
        public static event Action<Player, Collider2D> OnPlayerCollided;

        [SerializeField] AudioClip scoreClip;

        BoxCollider2D _boxCollider2D;
        AudioSource   _audioSource;



        private void Start()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _audioSource   = GetComponent<AudioSource>();

            _boxCollider2D.isTrigger = true;

            _audioSource.playOnAwake = false;
            _audioSource.clip        = scoreClip;
        }

        private void OnEnable()
        {
            OnPlayerCollided += OnCollidedWithPlayer;
        }

        private void OnDisable()
        {
            OnPlayerCollided -= OnCollidedWithPlayer;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Player player)) return;

            OnPlayerCollided?.Invoke(player, collision);
        }



        void OnCollidedWithPlayer(Player player, Collider2D collision)
        {
            _audioSource.Play();
        }
    }
}
