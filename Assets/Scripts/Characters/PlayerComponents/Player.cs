using Assets.Scripts.ScriptableObjects.Data;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
{
    [DisallowMultipleComponent]

    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(CircleCollider2D))]

    [RequireComponent(typeof(PlayerAction))]
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerCollision), typeof(PlayerAudio))]
    public class Player : MonoBehaviour
    {
        public const float GRAVITY = -9.81f;

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
