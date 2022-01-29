using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine<IPlayerState, PlayerStateType>
{
    protected override void Awake()
    {
        isPersistent = true;
        PrepareStates();
        base.Awake();
        Initialize(PlayerStateType.Physical);
    }

    private void PrepareStates()
    {
        states.Add(new PlayerPhysicalState());
        states.Add(new PlayerSpiritualState());
    }
}