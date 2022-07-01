using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
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



        public void PlayJumpSound() => source.Play();
    }
}
