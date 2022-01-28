using System;
using System.Collections.Generic;
using UnityEngine;

namespace KrakJam2022
{
    public class CameraZoom : MonoBehaviour, IInteractable
    {
        [SerializeField] protected new Camera camera;

        protected Camera defaultCamera;
        protected GameManager gameManager;

        private void Start()
        {
            this.gameManager = GameManager.Instance;
        }

        public void Interact()
        {
            if (this.defaultCamera != null)
            {
                this.Uninteract();
                return;
            }
            this.gameManager.BlockMove();
            this.defaultCamera = Camera.main;
            this.defaultCamera.gameObject.SetActive(false);
            this.camera.gameObject.SetActive(true);

        }

        private void Uninteract()
        {
            this.camera.gameObject.SetActive(false);
            this.defaultCamera.gameObject.SetActive(true);
            this.defaultCamera = null;
            this.gameManager.UnblockMove();
        }
    }
}