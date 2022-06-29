using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Scenes.Game.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "AudioMixerSnapshotData", menuName = "Custom Data/Audio Mixer Snapshot Data")]
    public class AudioMixerSnapshotDataSO : ScriptableObject
    {
        public AudioMixerSnapshot
            playing,
            paused,
            gameOver;
    }
}
