using UnityEngine;

namespace Assets.Scripts.Scenes.Game.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "AudioClipData", menuName = "Custom Data/Audio Clip Data")]
    public class AudioClipDataSO : ScriptableObject
    {
        public AudioClip gameOver;
    }
}
