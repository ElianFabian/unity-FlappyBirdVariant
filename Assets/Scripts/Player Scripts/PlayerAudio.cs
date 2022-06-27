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
            player.actionEventChannel.OnJump += PlayJumpSound;
        }

        private void OnDisable()
        {
            player.actionEventChannel.OnJump -= PlayJumpSound;
        }



        void PlayJumpSound() => source.Play();
    }
}
