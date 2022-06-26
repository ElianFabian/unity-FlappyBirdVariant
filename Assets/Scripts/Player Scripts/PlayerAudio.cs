﻿using UnityEngine;



namespace Assets.Scripts.PlayerScripts
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
            player.inputEventChannel.OnJumpKeyDown += PlayJumpSound;
        }

        private void OnDisable()
        {
            player.inputEventChannel.OnJumpKeyDown -= PlayJumpSound;
        }



        void PlayJumpSound() =>source.Play();
    }
}
