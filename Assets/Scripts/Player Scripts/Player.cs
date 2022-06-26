using UnityEngine;
using Assets.Scripts.Data;
using NaughtyAttributes;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]

    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerAction))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerCollision))]
    [RequireComponent(typeof(PlayerAction))]
    public class Player : MonoBehaviour
    {
        public const float GRAVITY = -9.81f;

        internal PlayerInput     input;
        internal PlayerAction    action;
        internal PlayerMovement  movement;
        internal PlayerCollision collision;
        internal PlayerAudio     audio;

        [OnValueChanged(nameof(LoadPlayerData))]
        public PlayerDataSO data;

        SpriteRenderer _spriteRenderer;



        void Awake()
        {
            input     = GetComponent<PlayerInput>();
            action    = GetComponent<PlayerAction>();
            movement  = GetComponent<PlayerMovement>();
            collision = GetComponent<PlayerCollision>();
            audio     = GetComponent<PlayerAudio>();
        }

        private void Start()
        {
            LoadPlayerData();
        }



        void LoadPlayerData()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.sprite = data.playerSprite;
            audio.source.clip      = data.jumpClip;
        }
    }
}
