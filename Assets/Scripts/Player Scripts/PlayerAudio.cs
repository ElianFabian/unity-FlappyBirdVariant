using UnityEngine;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudio : BasePlayerComponent
    {
        AudioSource _source;



        private void Start()
        {
            _source = GetComponent<AudioSource>();

            _source.playOnAwake = false;

            _source.clip = player.data.jumpClip;
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
            _source.Play();
        }
    }
}
