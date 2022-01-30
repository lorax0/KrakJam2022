using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace KrakJam2022
{
    public class PuzzleMove : MonoBehaviour
    {
        public Action OnFinish;

        [SerializeField] protected GameObject correctForm;

        protected Vector2 startPosition;
        protected Vector3 resetPosition;

        private void OnEnable()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            this.startPosition = new Vector2(mousePosition.x - this.transform.localPosition.x, mousePosition.y - this.transform.localPosition.y);
            this.resetPosition = this.transform.localPosition;
        }

        private void OnDisable()
        {
            if (this.IsDistanceCorrect())
            {
                this.transform.localPosition = this.correctForm.transform.localPosition;
                this.OnFinish?.Invoke();
            }
            else
            {
                this.transform.localPosition = this.resetPosition;
            }
        }

        private void Update()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            this.gameObject.transform.localPosition = new Vector3(mousePosition.x - this.startPosition.x, mousePosition.y - this.startPosition.y, this.transform.localPosition.z);
        }

        private bool IsDistanceCorrect()
        {
            return Mathf.Abs(this.transform.localPosition.x - this.correctForm.transform.localPosition.x) <= 0.5f && Mathf.Abs(this.transform.localPosition.y - this.correctForm.transform.localPosition.y) <= 0.5f;
        }

    }
}