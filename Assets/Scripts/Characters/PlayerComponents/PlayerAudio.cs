using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudio : MonoBehaviour, IPlayerAudio
    {
        [SerializeField] AudioClip _jumpClip;

        AudioSource _source;



        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _source.playOnAwake = false;
        }



        public void PlayJumpSound() => _source.PlayOneShot(_jumpClip);
    }
}
