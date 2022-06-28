﻿using Assets.Scripts.EventChannels;
using Assets.Scripts.ScriptableObjects.Data;
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

        private void OnEnable()
        {
            GameEvents.OnGameOver      += OnGameOver;
            GameEvents.OnGamePaused    += OnGamePaused;
            GameEvents.OnGameResumed   += OnGameResumed;
            GameEvents.OnGameRestarted += OnGameRestarted;
        }

        private void OnDisable()
        {
            GameEvents.OnGameOver      -= OnGameOver;
            GameEvents.OnGamePaused    -= OnGamePaused;
            GameEvents.OnGameResumed   -= OnGameResumed;
            GameEvents.OnGameRestarted -= OnGameRestarted;
        }

        #endregion

        #region Event functions

        void OnGamePaused()
        {
            _snapshotData.paused.TransitionTo(0.1f);
        }

        void OnGameResumed()
        {
            _snapshotData.playing.TransitionTo(0.1f);
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
