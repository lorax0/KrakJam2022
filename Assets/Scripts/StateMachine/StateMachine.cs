using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateMachine<T, W> : Singleton<StateMachine<T,W>> where T : IState<W> where W : Enum
{
    protected T currentState;
    protected T nextState;
    protected W previousStateType;
    protected W currentStateType;
    protected List<T> states = new List<T>();

    public T CurrentState => currentState;
    public W PreviousStateType => previousStateType;
    public W CurrentStateType => currentStateType;


    public void Initialize(W initState)
    {
        currentStateType = initState;
        if (HasCorrectState(currentStateType))
            currentState = GetStateByType(currentStateType);
        currentState.Enter();
    }

    public void Initialize(List<T> states, W initState)
    {
        this.states = states;
        Initialize(initState);
    }

    public virtual void Switch(W newStateType)
    {
        if (currentStateType.Equals(newStateType))
            return;

        if (HasCorrectState(newStateType))
            nextState = GetStateByType(newStateType);
        else
        {
            Debug.LogError($"Missing state: {newStateType}!");
            return;
        }
        currentState.Exit();
        previousStateType = currentState.Type;
        currentState = nextState;
        currentStateType = newStateType;
        currentState.Enter();
    }

    protected bool HasCorrectState(W stateType)
    {
        return states.Any(t => t.Type.Equals(stateType));
    }

    protected T GetStateByType(W stateType)
    {
        return states.FirstOrDefault(t => t.Type.Equals(stateType));
    }
}