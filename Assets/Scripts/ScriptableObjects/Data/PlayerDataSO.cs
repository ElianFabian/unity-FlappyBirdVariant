using UnityEngine;
using NaughtyAttributes;



namespace Assets.Scripts.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Custom Data/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [ShowAssetPreview]
        public Sprite playerSprite;

        public AudioClip jumpClip;
    }
}
