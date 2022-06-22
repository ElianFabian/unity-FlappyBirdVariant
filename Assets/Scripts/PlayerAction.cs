using UnityEngine;



namespace Assets.Scripts
{
    public class PlayerAction : BasePlayerComponent
    {
        public void Jump()
        {
            var newVelocity = player.rigidbody.velocity;

            newVelocity.y = Mathf.Sqrt(-2f * Player.GRAVITY * player.maxJumpHeight);

            player.rigidbody.velocity = newVelocity;
        }
    }
}