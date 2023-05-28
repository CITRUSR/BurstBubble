using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    private Dictionary<Type, IGameState> _states = new Dictionary<Type, IGameState>();
    private IGameState _currentState;

    public void AddState(IGameState newState)
    {
        _states.Add(newState.GetType(), newState);
    }

    public void SwitchState<T>() where T : IGameState
    {
        if (_states.TryGetValue(typeof(T), out IGameState state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}
