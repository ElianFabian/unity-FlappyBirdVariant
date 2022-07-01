using Assets.Scripts.Data.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        #region Fields

        [SerializeField] AudioMixerSnapshotDataSO _snapshotData;
        [SerializeField] AudioClipDataSO          _clipData;

        AudioSource _source;

        #endregion

        #region Unity event functions

        private void Awake()
        {
            _source = GetComponent<AudioSource>();

            _source.playOnAwake = false;
        }

        #endregion

        #region Event functions

        public void OnGamePaused()
        {
            _snapshotData.paused.TransitionTo(0.1f);
        }

        public void OnGameResumed()
        {
            _snapshotData.playing.TransitionTo(0.1f);
        }

        public void OnGameOver()
        {
            _snapshotData.gameOver.TransitionTo(2f);

            _source.PlayOneShot(_clipData.gameOver);
        }

        public void OnGameRestarted()
        {
            _snapshotData.playing.TransitionTo(0.01f);
        }

        #endregion
    }
}
