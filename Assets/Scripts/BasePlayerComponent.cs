using UnityEngine;



namespace Assets.Scripts
{
    public class BasePlayerComponent : MonoBehaviour
    {
        protected Player player;

        protected virtual void Start()
        {
            player = GetComponent<Player>();
        }
    }
}
