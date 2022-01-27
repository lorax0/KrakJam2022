using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : IGameState
{
    public GameStateType Type => GameStateType.Game;

    public void Enter()
    {
        Debug.LogError($"Enter {Type} state");
    }

    public void Exit()
    {
        Debug.LogError($"Exit {Type} state");
    }
}