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
            player.action.OnJump += OnJump;
        }

        private void OnDisable()
        {
            player.action.OnJump -= OnJump;
        }



        void OnJump()
        {
            source.clip = player.data.jumpClip;

            source.Play();
        }
    }
}