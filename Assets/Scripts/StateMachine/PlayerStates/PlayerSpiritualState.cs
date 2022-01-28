using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpiritualState : IPlayerState
{
    public PlayerStateType Type => PlayerStateType.Spiritual;

    public void Enter()
    {
        Debug.LogError($"Enter {Type} state");
    }

    public void Exit()
    {
        Debug.LogError($"Exit {Type} state");
    }
}