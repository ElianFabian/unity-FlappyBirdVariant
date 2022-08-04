using Assets.Scripts.Data.ScriptableObjects;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
{
    [DisallowMultipleComponent]

    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        [OnValueChanged(nameof(LoadPlayerDataInEditor))]
        public CharacterConfigurationSO data;


        CircleCollider2D _circleCollider;
        SpriteRenderer _spriteRenderer;



        private void Awake()
        {
            _circleCollider = GetComponent<CircleCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            LoadPlayerData();
        }



        void LoadPlayerData()
        {
            _spriteRenderer.sprite = data.playerSprite;

            _circleCollider.isTrigger = true;
            _circleCollider.offset    = data.colliderOffset;
            _circleCollider.radius    = data.colliderRadius;
        }



#if UNITY_EDITOR
        void LoadPlayerDataInEditor()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.sprite = data.playerSprite;
        }
#endif
    }
}
