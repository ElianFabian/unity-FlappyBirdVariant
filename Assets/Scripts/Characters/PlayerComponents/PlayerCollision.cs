using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
{
    [DisallowMultipleComponent]
    public class PlayerCollision : BasePlayerComponent
    {
        public CircleCollider2D circleCollider;



        protected override void Awake()
        {
            base.Awake();

            circleCollider = GetComponent<CircleCollider2D>();

            circleCollider.isTrigger = true;
            circleCollider.radius    = 1.8f;

            var offset = circleCollider.offset;
            offset.x = -0.2f;
            offset.y = 0.2f;

            circleCollider.offset = offset;
        }
    }
}
