using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    public class CloudSpawner : MonoBehaviour
    {
        const string CloudSortingLayer = "Clouds";
        const string SpritePath        = "Images/Background/clouds";

        [SerializeField] float _maxSpawnDelayInSeconds = 4f;
        [SerializeField] float _minSpawnDelayInSeconds = 2.2f;
        [SerializeField] float _spawnDelayInSeconds    = 5f;
        [SerializeField] float _spawnVelocity          = 1.5f;

        [SerializeField] float _heightOffset      = 4f;
        [SerializeField] float _minScale          = 0.3f;
        [SerializeField] float _maxScale          = 0.8f;
        [SerializeField] float _farthestColorRate = 0.83f;

        [SerializeField] int _numberOfLayers = 3;

        Sprite[] _cloudSprites;



        private void Awake()
        {
            _cloudSprites = Resources.LoadAll<Sprite>(SpritePath);
        }

        private void Start()
        {
            StartCoroutine(SpawnCloudCoroutine());
        }



        IEnumerator SpawnCloudCoroutine()
        {
            while (true)
            {
                var spriteIndex = Random.Range(0, _numberOfLayers);
                var layer       = Random.Range(0, _numberOfLayers);
                var height      = Random.Range(-_heightOffset, _heightOffset);

                var sprite   = _cloudSprites[spriteIndex];
                var position = transform.position + Vector3.up * height;

                var colorFactorFromDistance = Map(layer, 0, _numberOfLayers - 1, 1f, _farthestColorRate);
                var scaleFactorFromDistance = Map(layer, 0, _numberOfLayers - 1, _maxScale, _minScale);

                var color = Color.HSVToRGB(0, 0, colorFactorFromDistance);


                var newCloud = new GameObject("Spawned Cloud");

                newCloud.transform.position   = position;
                newCloud.transform.localScale = Vector3.one * scaleFactorFromDistance;

                newCloud.AddComponent<SpawnedObjectTag>();
                newCloud.AddComponent<BoxCollider2D>().isTrigger = true;

                var renderer = newCloud.AddComponent<SpriteRenderer>();

                renderer.sprite           = sprite;
                renderer.color            = color;
                renderer.sortingOrder     = -layer;
                renderer.sortingLayerName = CloudSortingLayer;

                var rigidbody = newCloud.AddComponent<Rigidbody2D>();

                rigidbody.bodyType = RigidbodyType2D.Kinematic;
                rigidbody.velocity = Vector2.left * (_spawnVelocity * scaleFactorFromDistance);


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
