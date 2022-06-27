using Assets.Scripts.ScriptableObjects.Data;
using Assets.Scripts.ScriptableObjects.Events;
using NaughtyAttributes;
using UnityEngine;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]

    [RequireComponent(typeof(PlayerAction))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerCollision))]
    [RequireComponent(typeof(PlayerAction))]
    public class Player : MonoBehaviour
    {
        public const float GRAVITY = -9.81f;

        [SerializeField] internal PlayerActionEventChannelSO inputEventChannel;
        [SerializeField]          GameEventChannelSO        _gameEventChannel;

        internal PlayerAction    action;
        internal PlayerMovement  movement;
        internal PlayerCollision collision;
        internal PlayerAudio     audio;

        [OnValueChanged(nameof(LoadPlayerData))]
        public PlayerDataSO data;

        SpriteRenderer _spriteRenderer;



        void Awake()
        {
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
