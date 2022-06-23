using UnityEngine;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerInput : BasePlayerComponent
    {
        public KeyCode jumpKey = KeyCode.Space;

        private void Update()
        {
            player.isJumpPressed = Input.GetKeyDown(jumpKey);
        }
    }
}
