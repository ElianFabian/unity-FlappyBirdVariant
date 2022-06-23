using UnityEngine;
using UnityEngine.SceneManagement;



namespace Assets.Scripts.Util
{
    // Be carefull, avoid making this GameObject a child of another
    // if that object is destroyed this one will be too.

    /// <summary>
    /// The GameObject won't be destroyed when reloading but it will
    /// when changing to a different scene.
    /// </summary>
    [DisallowMultipleComponent]
    public class DontDestroyOnReload : MonoBehaviour
    {
        static DontDestroyOnReload Instance;

        Scene initialScene;

        private void Awake()
        {
            initialScene = SceneManager.GetActiveScene();

            DontDestroyOnLoad(gameObject);

            if (Instance == null)
            {
                Instance = this;
            }
            else Destroy(gameObject);
        }

        private void OnLevelWasLoaded(int level)
        {
            var currentScene = SceneManager.GetActiveScene();

            if (currentScene != initialScene) Destroy(gameObject);
        }
    }
}
