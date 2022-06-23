using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerMovement : BasePlayerComponent
    {
        private void Update()
        {
            if (player.isJumpPressed) player.action.Jump();
        }
    }
}
