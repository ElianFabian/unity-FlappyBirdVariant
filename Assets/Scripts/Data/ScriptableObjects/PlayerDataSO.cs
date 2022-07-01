using Assets.Scripts.BaseClasses;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Player Data")]
    public class PlayerDataSO : BaseDescriptionSO
    {
        [ShowAssetPreview]
        public Sprite playerSprite;

        public AudioClip jumpClip;
    }
}
