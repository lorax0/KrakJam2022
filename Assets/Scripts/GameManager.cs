using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KrakJam2022
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public InputActionReference ClickAction => this.clickAction;

        [SerializeField] protected InputActionAsset actionAsset;
        [SerializeField] protected List<InputActionReference> actionsToBlockOnInteraction;
        [SerializeField] protected InputActionReference clickAction;

        private List<IGameState> states = new List<IGameState>();
        private bool hasMission = false;

        public Action<bool> OnChangeMoveStatus;
        public bool HasMission { get => hasMission; set => hasMission = value; }

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
            OnChangeMoveStatus?.Invoke(false);
        }

        public void UnblockMove()
        {
            foreach (var action in this.actionsToBlockOnInteraction)
            {
                action.action.Enable();
            }
            OnChangeMoveStatus?.Invoke(true);
        }
        
        private void PrepareGameStateMachine()
        {
            this.states.Add(new GameState());
            this.states.Add(new MainMenuState());
            this.states.Add(new LevelManagerState());
            GameStateMachine.Instance.Initialize(this.states, GameStateType.MainMenu);
        }
    }
}