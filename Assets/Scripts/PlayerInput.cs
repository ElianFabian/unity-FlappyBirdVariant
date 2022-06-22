using UnityEngine;



namespace Assets.Scripts
{
    public class PlayerInput : BasePlayerComponent
    {
        public readonly KeyCode jumpKey = KeyCode.Space;

        void Update()
        {
            player.isJumpPressed = Input.GetKeyDown(jumpKey);
        }
    }
}
