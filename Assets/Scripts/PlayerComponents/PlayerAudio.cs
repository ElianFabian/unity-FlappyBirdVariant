﻿using UnityEngine;



namespace Assets.Scripts.PlayerComponents
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudio : BasePlayerComponent
    {
        internal AudioSource source;



        protected override void Awake()
        {
            base.Awake();

            source = GetComponent<AudioSource>();

            source.playOnAwake = false;

            source.clip = player.data.jumpClip;
        }

        private void OnEnable()
        {
            PlayerInput.OnJump += PlayJumpSound;
        }

        private void OnDisable()
        {
            PlayerInput.OnJump -= PlayJumpSound;
        }



        void PlayJumpSound() => source.Play();
    }
}