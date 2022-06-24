using Assets.Scripts.PipeScripts;
using UnityEngine;



namespace Assets.Scripts.PipeScripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PipeDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out DeathZone collidedPipe)) return;

            // When it collides with a pipe we want to destroy it's parent group and the pipe itself.
            Destroy(collidedPipe.transform.parent.gameObject);
            Destroy(collision.gameObject);
            collidedPipe.transform.parent = null;
        }
    }
}
