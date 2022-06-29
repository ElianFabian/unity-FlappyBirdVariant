using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Assets.Scripts.Common.Util
{
    // Be careful, avoid making this GameObject a child of another
    // if that object is destroyed this one will be too.

    /// <summary>
    /// The GameObject won't be destroyed when reloading but it will
    /// when changing to a different scene.
    /// </summary>
    [DisallowMultipleComponent]
    public class DontDestroyOnReload : MonoBehaviour
    {
        [Scene]
        [SerializeField] string _initialScene;

        static DontDestroyOnReload Instance;

        private void Awake()
        {
            _initialScene = SceneManager.GetActiveScene().name;

            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }

        private void OnLevelWasLoaded(int level)
        {
            var currentScene = SceneManager.GetActiveScene().name;

            if (currentScene != _initialScene) Destroy(gameObject);
        }
    }
}
