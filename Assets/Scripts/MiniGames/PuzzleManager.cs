using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace KrakJam2022
{
    public class PuzzleManager : MonoBehaviour
    {
        public Action OnFinishPuzzle;

        [SerializeField] protected List<PuzzleElement> puzzles;

        private void Start()
        {
            foreach (var puzzleElement in this.puzzles)
            {
                puzzleElement.PuzzleMove.OnFinish += this.CheckPuzzleFinish;
            }
        }

        public void CheckPuzzleFinish()
        {
            foreach (var puzzleElement in this.puzzles)
            {
                if (puzzleElement.Finish == false) return;
            }
            this.OnFinishPuzzle?.Invoke();
        }
    }
}