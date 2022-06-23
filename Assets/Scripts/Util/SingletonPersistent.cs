using UnityEngine;



namespace Assets.Scripts.Util
{
    // From: https://youtu.be/Ova7l0UB26U
    public abstract class SingletonPersistent<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject
                    {
                        name = typeof(T).Name,
                        hideFlags = HideFlags.HideAndDontSave
                    }
                    .AddComponent<T>();

                    DontDestroyOnLoad(_instance);
                }

                return _instance;
            }
        }
    }
}
