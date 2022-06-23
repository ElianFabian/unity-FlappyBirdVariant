using UnityEngine;
using Assets.Scripts.Data;
using NaughtyAttributes;
using System;



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
    public class Player : MonoBehaviour
    {
        public const float GRAVITY = -9.81f;

        [SerializeField] internal PlayerInput    input;
        [SerializeField] internal PlayerAction   action;
        [SerializeField] internal PlayerMovement movement;
        [SerializeField] internal PlayerAudio    audio;

        [OnValueChanged(nameof(LoadPlayerData))]
        public PlayerDataSO data;

        public float maxJumpHeight = 2;

        [HideInInspector] public Rigidbody2D rigidbody;

        [HideInInspector] public bool isJumpPressed = false;

        SpriteRenderer   _spriteRenderer;
        CircleCollider2D _circleCollider2D;



        void Awake()
        {
            rigidbody         = GetComponent<Rigidbody2D>();
            _circleCollider2D = GetComponent<CircleCollider2D>();


            _circleCollider2D.isTrigger = true;
            _circleCollider2D.radius    = 2.4f;


            LoadPlayerData();
        }



        void LoadPlayerData()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.sprite = data.playerSprite;
        }
    }
}
