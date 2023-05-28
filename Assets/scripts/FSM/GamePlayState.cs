using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : IGameState
{
    private GameStateMachine _stateMachine;
    private BallDestroyer _destroyer;
    private EventBus _eventBus;

    public GamePlayState(GameStateMachine stateMachine,
     BallDestroyer destroyer,
     EventBus eventBus)
    {
        _stateMachine = stateMachine;
        _destroyer = destroyer;
        _eventBus = eventBus;
    }

    public void Enter()
    {
        _eventBus.Subscribe<LoseEvent>(Lose);
    }

    public void Exit()
    {
        _eventBus.Unubscribe<LoseEvent>(Lose);
        _destroyer.Destroy(Object.FindObjectsOfType<Ball>());
    }

    private void Lose(LoseEvent loseEvent)
    {
        _stateMachine.SwitchState<EndGameState>();
    }
}
