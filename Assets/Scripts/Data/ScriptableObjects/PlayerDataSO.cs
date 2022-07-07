using UnityEngine;

namespace Assets.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [SerializeField] PlayerConfigurationSO _configuration;

        [HideInInspector] public string name;
        [HideInInspector] public Sprite playerSprite;
        [HideInInspector] public AudioClip jumpClip;
        [HideInInspector] public Vector2 colliderOffset;
        [HideInInspector] public float colliderRadius;



        public void SetConfiguration(PlayerConfigurationSO configuration)
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
