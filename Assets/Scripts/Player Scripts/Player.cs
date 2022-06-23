﻿using UnityEngine;
using Assets.Scripts.Data;
using NaughtyAttributes;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]

    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerAction))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerCollision))]
    public class Player : MonoBehaviour
    {
        public const float GRAVITY = -9.81f;

        [OnValueChanged(nameof(LoadPlayerData))]
        [SerializeField] PlayerDataSO _playerData;

        public float maxJumpHeight = 2f;

        [HideInInspector] public PlayerInput    input;
        [HideInInspector] public PlayerAction   action;
        [HideInInspector] public PlayerMovement movement;

        [HideInInspector] public Rigidbody2D rigidbody;

        [HideInInspector] public bool isJumpPressed = false;

        private SpriteRenderer _spriteRenderer;



        void Awake()
        {
            input    = GetComponent<PlayerInput>();
            action   = GetComponent<PlayerAction>();
            movement = GetComponent<PlayerMovement>();

            rigidbody = GetComponent<Rigidbody2D>();

            LoadPlayerData();
        }



        void LoadPlayerData()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.sprite = _playerData.playerSprite;
        }
    }
}
