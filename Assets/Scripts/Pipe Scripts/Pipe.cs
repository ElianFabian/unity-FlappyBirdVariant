using UnityEngine;
using Assets.Scripts.PlayerScripts;

namespace Assets.Scripts.PipeScripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Pipe : MonoBehaviour
    {
        BoxCollider2D _boxCollider2D;
        Rigidbody2D   _rigidbody2D;



        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _rigidbody2D   = GetComponent<Rigidbody2D>();

            _boxCollider2D.isTrigger = true;

            var newColliderSize = _boxCollider2D.size;
            newColliderSize.x = 2.4f;

            _boxCollider2D.size = newColliderSize;
            _rigidbody2D.isKinematic = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player _))
            {
                GameManager.Instance.SetGameOver();
            }
        }
    }
}
