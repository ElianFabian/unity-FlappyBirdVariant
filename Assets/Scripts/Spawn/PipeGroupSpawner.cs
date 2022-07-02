using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    [DisallowMultipleComponent]
    public class PipeGroupSpawner : MonoBehaviour
    {
        [SerializeField] GameObject _pipeGroupPrefab;

        [SerializeField] float _spawnDelayInSeconds = 1.5f;
        [SerializeField] float _spawnVelocity       = 5f;
        [SerializeField] float _heightOffset        = 2f;

        WaitForSeconds _waitForSpawnDelay;



        private void Awake()
        {
            _waitForSpawnDelay = new WaitForSeconds(_spawnDelayInSeconds);
        }

        private void Start()
        {
            StartCoroutine(SpawnPipeGroupCoroutine());
        }



        IEnumerator SpawnPipeGroupCoroutine()
        {
            while (true)
            {
                yield return _waitForSpawnDelay;

                var height   = Random.Range(-_heightOffset, _heightOffset);
                var position = transform.position + Vector3.up * height;

                var newPipeGroup = Instantiate(_pipeGroupPrefab, position, Quaternion.identity);

                var rigidbody = newPipeGroup.GetComponent<Rigidbody2D>();

                rigidbody.bodyType = RigidbodyType2D.Kinematic;
                rigidbody.velocity = Vector2.left * _spawnVelocity;
            }
        }
    }
}
