using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicalState : IPlayerState
{
    public PlayerStateType Type => PlayerStateType.Physical;

    public void Enter()
    {
        Debug.LogError($"Enter {Type} state");
    }

    public void Exit()
    {
        Debug.LogError($"Exit {Type} state");
    }
}