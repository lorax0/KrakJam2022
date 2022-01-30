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
        protected bool finish;

        private void Awake()
        {
            this.puzzleMove = this.GetComponent<PuzzleMove>();
            this.puzzleMove.OnFinish += () => this.finish = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;
            if (this.finish) return;
            this.puzzleMove.enabled = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.puzzleMove.enabled = false;
        }
    }
}