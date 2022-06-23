using UnityEngine;
using NaughtyAttributes;



namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Custom Data/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [ShowAssetPreview]
        public Sprite playerSprite;
    }
}
