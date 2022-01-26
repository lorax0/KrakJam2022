using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] protected InputActionAsset actionAsset;

        private void OnEnable()
        {
            this.actionAsset.Enable();
        }
    }
}
