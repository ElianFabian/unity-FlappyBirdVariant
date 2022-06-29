﻿using UnityEngine;
using UnityEngine.UI;



namespace Assets.Scripts.ScriptableObjects.Data
{
    [DisallowMultipleComponent]
    public class UIMainMenuBinding : MonoBehaviour
    {
        public static UIMainMenuBinding instance;

        public Button btnChooseYourSkin;
        public Button btnHelp;



        private void Awake()
        {
            instance = this;
        }
    }
}