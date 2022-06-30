using UnityEngine;

namespace Assets.Scripts.Spawn
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpawnedObjectDeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out SpawnedObjectTag spawnedObject)) return;

            Destroy(spawnedObject.gameObject);
        }
    }
}
