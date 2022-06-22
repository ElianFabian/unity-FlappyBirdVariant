using UnityEngine;



namespace Assets.Scripts.Util
{
    // From: https://youtu.be/Ova7l0UB26U
    public class SingletonPersistent<T> : MonoBehaviour where T: Component
    {
        private static T _instance;

        public static T Instance {
            get
            {
                //if (_instance == null)
                //{
                //    return new GameObject
                //    {
                //        name = typeof(T).Name,
                //        hideFlags = HideFlags.HideAndDontSave
                //    }
                //    .AddComponent<T>();
                //}
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;

                DontDestroyOnLoad(gameObject);
            }

            else Destroy(this);
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this) _instance = null;
        }
    }
}
