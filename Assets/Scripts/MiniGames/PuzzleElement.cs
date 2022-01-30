using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace KrakJam2022
{
    public class PuzzleElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public PuzzleMove PuzzleMove => this.puzzleMove;
        public bool Finish => this.finish;

        protected PuzzleMove puzzleMove;
        protected SpriteRenderer spriteRenderer;
        protected bool finish;
        protected const int MoveOrderLayer = 3;
        protected const int DefaultOrderLayer = 2;

        private void Awake()
        {
            this.puzzleMove = this.GetComponent<PuzzleMove>();
            this.spriteRenderer = this.GetComponent<SpriteRenderer>();
            this.spriteRenderer.sortingOrder = DefaultOrderLayer;
            this.puzzleMove.OnFinish += () => this.finish = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;
            if (this.finish) return;
            this.puzzleMove.enabled = true;
            this.spriteRenderer.sortingOrder = MoveOrderLayer;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.puzzleMove.enabled = false;
            this.spriteRenderer.sortingOrder = DefaultOrderLayer;
        }
    }
}