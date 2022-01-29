using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine<IGameState, GameStateType>
{
    protected override void Awake()
    {
        isPersistent = true;
        base.Awake();
    }
}