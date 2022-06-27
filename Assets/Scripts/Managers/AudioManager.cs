using Assets.Scripts.ScriptableObjects.Data;
using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;



namespace Assets.Scripts.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        #region Fields

        [SerializeField] AudioMixerSnapshotDataSO _snapshotData;
        [SerializeField] AudioClipDataSO          _clipData;

        [SerializeField] GameEventChannelSO _gameEventChannel;

        AudioSource _source;

        #endregion

        #region Unity event functions

        private void Awake()
        {
            _source = GetComponent<AudioSource>();

            _source.playOnAwake = false;
        }

        private void OnEnable()
        {
            _gameEventChannel.OnGameOver      += OnGameOver;
            _gameEventChannel.OnGamePaused    += OnGamePaused;
            _gameEventChannel.OnGameResumed   += OnGameResumed;
            _gameEventChannel.OnGameRestarted += OnGameRestarted;
        }

        private void OnDisable()
        {
            _gameEventChannel.OnGameOver      -= OnGameOver;
            _gameEventChannel.OnGamePaused    -= OnGamePaused;
            _gameEventChannel.OnGameResumed   -= OnGameResumed;
            _gameEventChannel.OnGameRestarted -= OnGameRestarted;
        }

        #endregion

        #region Event functions

        void OnGamePaused()
        {
            _snapshotData.paused.TransitionTo(0.25f);
        }

        void OnGameResumed()
        {
            _snapshotData.playing.TransitionTo(0.25f);
        }

        void OnGameOver()
        {
            _snapshotData.gameOver.TransitionTo(2f);

            _source.PlayOneShot(_clipData.gameOver);
        }

        void OnGameRestarted()
        {
            _snapshotData.playing.TransitionTo(0.01f);
        }

        #endregion
    }
}
