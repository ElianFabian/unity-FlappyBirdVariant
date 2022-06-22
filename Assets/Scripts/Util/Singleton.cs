using UnityEngine;



namespace Assets.Scripts.Util
{
    // From: https://youtu.be/Ova7l0UB26U
    public class Singleton<T> : MonoBehaviour where T: Component
    {
        private static T _instance;

        public static T Instance {
            get
            {
                if (_instance == null)
                {
                    return new GameObject
                    {
                        name = typeof(T).Name,
                        hideFlags = HideFlags.HideAndDontSave
                    }
                    .AddComponent<T>();
                }
                return _instance;
            }
        }

        private void OnDestroy()
        {
            if (_instance == this) _instance = null;
        }
    }
}
