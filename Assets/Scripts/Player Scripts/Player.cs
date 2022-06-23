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
    [RequireComponent(typeof(PlayerAction))]
    public class Player : MonoBehaviour
    {
        public const float GRAVITY = -9.81f;

        [SerializeField] internal PlayerInput     input;
        [SerializeField] internal PlayerAction    action;
        [SerializeField] internal PlayerMovement  movement;
        [SerializeField] internal PlayerCollision collision;
        [SerializeField] internal PlayerAudio     audio;

        [OnValueChanged(nameof(LoadPlayerData))]
        public PlayerDataSO data;

        [HideInInspector] public bool isJumpPressed = false;

        SpriteRenderer _spriteRenderer;



        void Awake()
        {
            LoadPlayerData();
        }



        void LoadPlayerData()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.sprite = data.playerSprite;
        }
    }
}
