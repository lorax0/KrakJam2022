using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<TStateType> where TStateType : Enum
{
    TStateType Type { get; }
    void Enter();
    void Exit();
}
