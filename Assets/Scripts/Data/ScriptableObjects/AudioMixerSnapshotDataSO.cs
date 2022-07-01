using Assets.Scripts.BaseClasses;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Audio Mixer Snapshot Data")]
    public class AudioMixerSnapshotDataSO : BaseDescriptionSO
    {
        public AudioMixerSnapshot
            playing,
            paused,
            gameOver;
    }
}
