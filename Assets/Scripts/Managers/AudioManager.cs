using UnityEngine;
using UnityEngine.Audio;
using Assets.Scripts.ScriptableObjects.Events;



namespace Assets.Scripts.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] GameEventChannelSO _gameEventChannel;

        [SerializeField] AudioMixerSnapshot _playingSnapshot;
        [SerializeField] AudioMixerSnapshot _pausedSnapshot;
        [SerializeField] AudioMixerSnapshot _gameOverSnapshot;

        [SerializeField] AudioClip _gameOverClip;

        AudioSource _source;



        private void Awake()
        {
            _source = GetComponent<AudioSource>();

            _source.playOnAwake = false;
            _source.loop        = true;
        }

        private void OnEnable()
        {
            _gameEventChannel.OnGameOver    += OnGameOver;
            _gameEventChannel.OnGamePaused  += OnGamePaused;
            _gameEventChannel.OnGameResumed += OnGameResumed;
        }

        private void OnDisable()
        {
            _gameEventChannel.OnGameOver    -= OnGameOver;
            _gameEventChannel.OnGamePaused  -= OnGamePaused;
            _gameEventChannel.OnGameResumed -= OnGameResumed;
        }



        void OnGamePaused()
        {
            _pausedSnapshot.TransitionTo(0.01f);
        }

        void OnGameResumed()
        {
            _playingSnapshot.TransitionTo(0.01f);
        }

        void OnGameOver()
        {
            _gameOverSnapshot.TransitionTo(2f);

            _source.PlayOneShot(_gameOverClip);

        }
    }
}
