using UnityEngine;
using System.Collections;



namespace Assets.Scripts
{
    public class CloudSpawner : MonoBehaviour
    {
        const string SPRITE_PATH = "Images/Background/clouds";
        const int BASE_CLOUD_SORTING_ORDER = -20;



        [SerializeField] Sprite[] _spriteClouds;

        [SerializeField] float _maxSpawnDelayInSeconds = 5f;
        [SerializeField] float _minSpawnDelayInSeconds = 3f;
        [SerializeField] float _spawnDelayInSeconds    = 5f;
        [SerializeField] float _spawnVelocity          = 1.5f;
        [SerializeField] float _heightOffset           = 1.5f;

        // From nearest to farest
        float[] _cloudScaleAccordingToDistance = new float[] { 0.8f, 0.5f, 0.3f };

        private void Start()
        {
            _spriteClouds = Resources.LoadAll<Sprite>(SPRITE_PATH);

            StartCoroutine(SpawnCloudCoroutine());
        }



        IEnumerator SpawnCloudCoroutine()
        {
            while (true)
            {
                var spriteCloudIndex   = Random.Range(0, _spriteClouds.Length);
                var heightFactor       = Random.Range(-_heightOffset, _heightOffset);
                var sizeTypeCloudIndex = Random.Range(0, 3);

                var randomHeight        = transform.position + Vector3.up * heightFactor;

                var cloudScale = _cloudScaleAccordingToDistance[sizeTypeCloudIndex];

                var newCloud = new GameObject("Spawned Cloud");

                newCloud.transform.position   = randomHeight;
                newCloud.transform.localScale = Vector3.one * cloudScale;

                newCloud.AddComponent<SpawnedObjectTag>();
                newCloud.AddComponent<BoxCollider2D>().isTrigger = true;

                var spriteRenderer = newCloud.AddComponent<SpriteRenderer>();

                spriteRenderer.sprite       = _spriteClouds[spriteCloudIndex];

                var colorRelatedToDistance = Color.white * Map(sizeTypeCloudIndex, 0f, 2, 1f, 0.86f);
                colorRelatedToDistance.a   = 1;
                spriteRenderer.color       = colorRelatedToDistance;

                spriteRenderer.sortingOrder = BASE_CLOUD_SORTING_ORDER - sizeTypeCloudIndex;

                var newColudRigidBody = newCloud.AddComponent<Rigidbody2D>();

                newColudRigidBody.bodyType = RigidbodyType2D.Kinematic;
                newColudRigidBody.velocity = _spawnVelocity * cloudScale * Vector2.left;



                var randomDelay = Random.Range(_minSpawnDelayInSeconds, _maxSpawnDelayInSeconds);

                yield return new WaitForSeconds(randomDelay);
            }
        }

        /// <summary>
        /// Converts a value t in a range [a1, b1] into a value in a range [a2, b2].
        /// </summary>
        float Map(float t, float a1, float b1, float a2, float b2) => a2 + (b2 - a2) * (t - a1)/(b1 - a1);
    }
}