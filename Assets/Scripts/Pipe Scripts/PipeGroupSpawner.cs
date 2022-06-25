using UnityEngine;
using System.Collections;



namespace Assets.Scripts.PipeScripts
{
    [DisallowMultipleComponent]
    public class PipeGroupSpawner : MonoBehaviour
    {
        [SerializeField] GameObject _pipeGroupPrefab;

        [SerializeField] float _spawnDelayInSeconds = 1.5f;
        [SerializeField] float _spawnVelocity       = 5f;
        [SerializeField] float _heightOffset        = 2f;

        WaitForSeconds _waitForSpawnDelay;



        private void Start()
        {
            _waitForSpawnDelay = new WaitForSeconds(_spawnDelayInSeconds);

            StartCoroutine(SpawnPipeGroupCoroutine());
        }

        IEnumerator SpawnPipeGroupCoroutine()
        {
            while (true)
            {
                yield return _waitForSpawnDelay;

                var randomFactor = Random.Range(-_heightOffset, _heightOffset);
                var randomHeight = transform.position + Vector3.up * randomFactor;

                var newPipeGroup = Instantiate(_pipeGroupPrefab, randomHeight, Quaternion.identity).gameObject;
                
                var pipeGroupRigidBody = newPipeGroup.GetComponent<Rigidbody2D>();

                pipeGroupRigidBody.isKinematic = true;
                pipeGroupRigidBody.velocity    = Vector2.left * _spawnVelocity;
            }
        }
    }
}
