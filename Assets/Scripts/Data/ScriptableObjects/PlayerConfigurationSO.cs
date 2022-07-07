using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Player Configuration Data")]
    public class PlayerConfigurationSO : ScriptableObject
    {
        public string name;

        [ShowAssetPreview]
        public Sprite playerSprite;
        public AudioClip jumpClip;
        public Vector2 colliderOffset;
        public int colliderRadius;
    }
}