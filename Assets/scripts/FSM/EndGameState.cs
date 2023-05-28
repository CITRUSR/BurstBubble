using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : IGameState
{
    private GameStateMachine _stateMachine;
    private BallSpawner _ballSpawner;
    private ISaver _saver;
    private ILoader _loader;
    private ScoreCounter _scoreCounter;
    private LoseWindow _loseWindow;

    public EndGameState(GameStateMachine stateMachine,
     BallSpawner ballSpawner,
      ISaver saver,
       ILoader loader,
       ScoreCounter counter,
       LoseWindow loseWindow)
    {
        _stateMachine = stateMachine;
        _ballSpawner = ballSpawner;
        _saver = saver;
        _loader = loader;
        _scoreCounter = counter;
        _loseWindow = loseWindow;
    }

    public void Enter()
    {
        _ballSpawner.StopSpawn();
        SaveScore();
        _loseWindow.Init(_stateMachine, _scoreCounter, _loader);
    }

    public void Exit()
    {

    }

    private void SaveScore()
    {
        GameData data = (GameData)_loader.Load();
        if (data.Score < _scoreCounter.Score)
        {
            _saver.Save(new GameData(_scoreCounter));
        }
    }
}
