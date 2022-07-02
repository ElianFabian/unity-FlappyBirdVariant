using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    public class CloudSpawner : MonoBehaviour
    {
        const string SpritePath        = "Images/Background/clouds";
        const string CloudSortingLayer = "Clouds";

        [SerializeField] float _maxSpawnDelayInSeconds = 4f;
        [SerializeField] float _minSpawnDelayInSeconds = 2.2f;
        [SerializeField] float _spawnDelayInSeconds    = 5f;
        [SerializeField] float _spawnVelocity          = 1.5f;
        [SerializeField] float _heightOffset           = 4f;

        Sprite[] _spriteClouds;

        readonly float[] _cloudScaleFromNearToFar = new float[] { 0.8f, 0.5f, 0.3f };



        private void Awake()
        {
            _spriteClouds = Resources.LoadAll<Sprite>(SpritePath);
        }

        private void Start()
        {
            StartCoroutine(SpawnCloudCoroutine());
        }



        IEnumerator SpawnCloudCoroutine()
        {
            var numberOfDistanceTypes = _cloudScaleFromNearToFar.Length;
            var remotenessColorRate   = 0.82f;

            while (true)
            {
                var spriteIndex    = Random.Range(0, numberOfDistanceTypes);
                var scaleTypeIndex = Random.Range(0, numberOfDistanceTypes);
                var height         = Random.Range(-_heightOffset, _heightOffset);

                var distanceRate = Map(scaleTypeIndex, 0, numberOfDistanceTypes - 1, 1f, remotenessColorRate);
                var position     = transform.position + Vector3.up * height;
                var scale        = _cloudScaleFromNearToFar[scaleTypeIndex];

                var colorBasedOnDistance = Color.white * distanceRate;
                colorBasedOnDistance.a   = 1;


                var newCloud = new GameObject("Spawned Cloud");

                newCloud.transform.position   = position;
                newCloud.transform.localScale = Vector3.one * scale;

                newCloud.AddComponent<SpawnedObjectTag>();
                newCloud.AddComponent<BoxCollider2D>().isTrigger = true;

                var renderer = newCloud.AddComponent<SpriteRenderer>();

                renderer.color            = colorBasedOnDistance;
                renderer.sortingOrder     = -scaleTypeIndex;
                renderer.sortingLayerName = CloudSortingLayer;
                renderer.sprite           = _spriteClouds[spriteIndex];

                var rigidbody = newCloud.AddComponent<Rigidbody2D>();

                rigidbody.bodyType = RigidbodyType2D.Kinematic;
                rigidbody.velocity = _spawnVelocity * scale * Vector2.left;


                var randomDelay = Random.Range(_minSpawnDelayInSeconds, _maxSpawnDelayInSeconds);

                yield return new WaitForSeconds(randomDelay);
            }
        }

        /// <summary>
        /// Converts a value t in range [a1, b1] into a value in range [a2, b2].
        /// </summary>
        float Map(float t, float a1, float b1, float a2, float b2) => a2 + (b2 - a2) * (t - a1)/(b1 - a1);
    }
}
