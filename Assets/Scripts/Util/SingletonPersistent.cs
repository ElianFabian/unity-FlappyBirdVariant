using UnityEngine;



namespace Assets.Scripts.Util
{
    // From: https://youtu.be/Ova7l0UB26U
    public abstract class SingletonPersistent<T> : MonoBehaviour where T : Component
    {
        private static T _instance;
        public static T Instance { get => _instance; }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;

                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this) _instance = null;
        }
    }
}
