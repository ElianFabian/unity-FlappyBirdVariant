using Assets.Scripts.BaseClasses;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Character Configuration Data")]
    public class CharacterConfigurationSO : BaseDescriptionSO
    {
        public string name;
        [ShowAssetPreview]
        public Sprite playerSprite;
        public AudioClip jumpClip;
        public Vector2 colliderOffset;
        public int colliderRadius;

        CharacterConfigurationSO _configuration;

        public void SetConfiguration(CharacterConfigurationSO configuration)
        {
            _configuration = configuration;

            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            name           = _configuration.name;
            playerSprite   = _configuration.playerSprite;
            jumpClip       = _configuration.jumpClip;
            colliderOffset = _configuration.colliderOffset;
            colliderRadius = _configuration.colliderRadius;
        }
    }
}