﻿using UnityEngine;



namespace Assets.Scripts.PlayerScripts
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