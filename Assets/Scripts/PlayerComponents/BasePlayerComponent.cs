using UnityEngine;



namespace Assets.Scripts.PlayerComponents
{
    public abstract class BasePlayerComponent : MonoBehaviour
    {
        protected Player player;



        protected virtual void Awake()
        {
            player = GetComponent<Player>();
        }
    }
}
