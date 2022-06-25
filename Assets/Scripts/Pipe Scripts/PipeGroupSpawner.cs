using UnityEngine;
using System.Collections;



namespace Assets.Scripts.PipeScripts
{
    [DisallowMultipleComponent]
    public class PipeGroupSpawner : MonoBehaviour
    {
        [SerializeField] PipeGroup pipeGroupPrefab;

        [SerializeField] float spawnDelayInSeconds = 1.5f;
        [SerializeField] float spawnVelocity       = 5f;
        [SerializeField] float heightOffset        = 2f;

        WaitForSeconds waitForSpawnDelay;



        private void Awake()
        {
            waitForSpawnDelay = new WaitForSeconds(spawnDelayInSeconds);
        }

        private void Start()
        {
            StartCoroutine(SpawnPipeGroupCoroutine());
        }

        IEnumerator SpawnPipeGroupCoroutine()
        {
            while (true)
            {
                yield return waitForSpawnDelay;

                var randomFactor = Random.Range(-heightOffset, heightOffset);
                var randomHeight = transform.position + Vector3.up * randomFactor;

                var newPipeGroup = Instantiate(pipeGroupPrefab, randomHeight, Quaternion.identity).gameObject;
                
                var pipeGroupRigidBody = newPipeGroup.AddComponent<Rigidbody2D>();

                pipeGroupRigidBody.isKinematic = true;
                pipeGroupRigidBody.velocity = Vector2.left * spawnVelocity;
            }
        }
    }
}
