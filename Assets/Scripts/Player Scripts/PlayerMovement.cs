using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerMovement : BasePlayerComponent
    {
        void Update()
        {
            if (player.isJumpPressed) player.action.Jump();
        }
    }
}