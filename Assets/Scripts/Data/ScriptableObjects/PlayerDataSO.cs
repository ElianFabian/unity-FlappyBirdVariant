using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [ShowAssetPreview]
        public Sprite playerSprite;

        public AudioClip jumpClip;
    }
}
