using Assets.Scripts.BaseClasses;
using UnityEngine;

namespace Assets.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Audio Clip Data")]
    public class AudioClipDataSO : BaseDescriptionSO
    {
        public AudioClip gameOver;
    }
}
