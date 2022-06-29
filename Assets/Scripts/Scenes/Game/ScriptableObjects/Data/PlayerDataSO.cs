using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Scenes.Game.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Custom Data/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [ShowAssetPreview]
        public Sprite playerSprite;

        public AudioClip jumpClip;
    }
}
