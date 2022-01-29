using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KrakJam2022
{
    public class InteractCamera : MonoBehaviour
    {
        protected GameManager gameManager;
        protected Camera camera;

        private void Start()
        {
            this.gameManager = GameManager.Instance;
            this.camera = this.GetComponent<Camera>();
        }

        void Update()
        {
            InputActionManager.WasPressedButtonThisFrame(this.gameManager.ClickAction, this.InteractWithClickObject);
            
        }

        private void InteractWithClickObject()
        {
            Ray ray;
            RaycastHit hit;

            ray = this.camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit))
            {
                InteractiveItem item = hit.transform.gameObject.GetComponent<InteractiveItem>();
                item?.Interact();
            }
        }
    }
}