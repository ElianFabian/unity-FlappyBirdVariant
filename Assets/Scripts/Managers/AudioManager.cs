using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Audio;



namespace Assets.Scripts.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameEventChannelSO _gameEventChannel;

        [SerializeField] AudioMixerSnapshot _playingSnapshot;
        [SerializeField] AudioMixerSnapshot _pausedSnapshot;
        [SerializeField] AudioMixerSnapshot _gameOverSnapshot;

        [SerializeField] AudioClip _gameOverClip;

        AudioSource _source;

        #endregion

        #region Unity event functions

        private void Awake()
        {
            _source = GetComponent<AudioSource>();

            _source.playOnAwake = false;
            _source.loop        = true;
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
            _pausedSnapshot.TransitionTo(0.25f);
        }

        void OnGameResumed()
        {
            _playingSnapshot.TransitionTo(0.25f);
        }

        void OnGameOver()
        {
            _gameOverSnapshot.TransitionTo(2f);

            _source.PlayOneShot(_gameOverClip);
        }

        void OnGameRestarted()
        {
            _playingSnapshot.TransitionTo(0.01f);
        }

        #endregion
    }
}
