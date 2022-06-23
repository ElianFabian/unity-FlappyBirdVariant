using UnityEngine;
using System.Collections;




namespace Assets.Scripts.PipeScripts
{
    [DisallowMultipleComponent]
    public class PipeGroupSpawner : MonoBehaviour
    {
        [SerializeField] PipeGroup pipeGroupPrefab;
        [SerializeField] float spawnDelayInSeconds      = 1f;
        [SerializeField] float spawnedGroupPipeVelocity = 5f;

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

                GameObject newPipeGroup = Instantiate(pipeGroupPrefab, transform.position, Quaternion.identity).gameObject;
                
                var pipeGroupRigidBody = newPipeGroup.AddComponent<Rigidbody2D>();

                pipeGroupRigidBody.isKinematic = true;
                pipeGroupRigidBody.velocity = Vector2.left * spawnedGroupPipeVelocity;
            }
        }
    }
}
