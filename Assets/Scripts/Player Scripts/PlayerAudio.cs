using UnityEngine;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudio : BasePlayerComponent
    {
        AudioSource source;



        private void Start()
        {
            source = GetComponent<AudioSource>();

            source.playOnAwake = false;
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
            source.clip = player.data.jumpClip;

            source.Play();
        }
    }
}
