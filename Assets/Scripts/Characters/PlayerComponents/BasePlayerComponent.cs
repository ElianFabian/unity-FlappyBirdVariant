using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
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
