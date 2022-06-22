using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : BasePlayerComponent
    {
        void Update()
        {
            if (player.isJumpPressed) player.action.Jump();
        }
    }
}