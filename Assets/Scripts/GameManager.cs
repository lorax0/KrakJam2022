using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KrakJam2022
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] protected InputActionAsset actionAsset;
        [SerializeField] protected List<InputActionReference> actionsToBlockOnInteraction;

        private List<IGameState> states = new List<IGameState>();

        protected override void Awake()
        {
            isPersistent = true;
            base.Awake();
        }

        private void Start()
        {
            this.PrepareGameStateMachine();
        }

        private void OnEnable()
        {
            this.actionAsset.Enable();
        }

        private void OnDisable()
        {
            this.actionAsset.Disable();
        }

        public void BlockMove()
        {
            foreach (var action in this.actionsToBlockOnInteraction)
            {
                action.action.Disable();
            }
        }

        public void UnblockMove()
        {
            foreach (var action in this.actionsToBlockOnInteraction)
            {
                action.action.Enable();
            }
        }
        
        private void PrepareGameStateMachine()
        {
            this.states.Add(new GameState());
            this.states.Add(new MainMenuState());
            GameStateMachine.Instance.Initialize(this.states, GameStateType.MainMenu);
        }
    }
}