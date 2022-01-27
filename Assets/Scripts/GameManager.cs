using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] protected InputActionAsset actionAsset;

        private List<IGameState> states = new List<IGameState>();

        private void OnEnable()
        {
            this.actionAsset.Enable();
        }

        private void Start()
        {
            PrepareGameStateMachine();
        }

        private void PrepareGameStateMachine()
        {
            states.Add(new GameState());
            states.Add(new MainMenuState());
            GameStateMachine.Instance.Initialize(states, GameStateType.MainMenu);
        }
    }
}