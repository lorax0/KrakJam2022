using System;
using System.Collections.Generic;
using UnityEngine;

namespace KrakJam2022
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] protected InteractCamera interactCamera;
        
        protected GameManager gameManager;

        private void Start()
        {
            this.gameManager = GameManager.Instance;
        }

        public void ZoomIn()
        {
            if (this.interactCamera.gameObject.activeSelf == true)
            {
                this.ZoomOut();
                return;
            }
            this.gameManager.BlockMove();
            this.interactCamera.gameObject.SetActive(true);

        }

        public void ZoomOut()
        {
            this.interactCamera.gameObject.SetActive(false);
            this.gameManager.UnblockMove();
        }
    }
}