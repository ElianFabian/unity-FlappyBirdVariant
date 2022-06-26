using UnityEngine;



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
            PlayerAction.OnJump += OnJump;
        }

        private void OnDisable()
        {
            PlayerAction.OnJump -= OnJump;
        }



        void OnJump()
        {
            source.Play();
        }
    }
}
