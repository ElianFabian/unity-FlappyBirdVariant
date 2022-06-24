﻿using UnityEngine;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerCollision : MonoBehaviour
    {
        CircleCollider2D _circleCollider2D;



        private void Start()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();

            _circleCollider2D.isTrigger = true;
            _circleCollider2D.radius    = 1.8f;
        }
    }
}
