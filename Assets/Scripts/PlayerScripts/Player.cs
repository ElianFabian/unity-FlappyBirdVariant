using UnityEngine;


namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]

    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerAction))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerCollision))]
    public class Player : MonoBehaviour
    {
        public const float GRAVITY = -9.81f;

        public PlayerInput    input;
        public PlayerAction   action;
        public PlayerMovement movement;

        public Rigidbody2D     rigidbody;

        public float maxJumpHeight = 2f;

        public bool isJumpPressed = false;

        private SpriteRenderer _spriteRenderer;



        void Awake()
        {
            input    = GetComponent<PlayerInput>();
            action   = GetComponent<PlayerAction>();
            movement = GetComponent<PlayerMovement>();

            rigidbody      = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}