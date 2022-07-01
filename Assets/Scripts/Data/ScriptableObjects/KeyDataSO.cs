using Assets.Scripts.BaseClasses;
using UnityEngine;

namespace Assets.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Key Data")]
    public class KeyDataSO : BaseDescriptionSO
    {
        public KeyCode
            jumpKey,
            pauseKey;
    }
}
