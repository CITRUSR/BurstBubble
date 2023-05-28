using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameState : IGameState
{
    private GameStateMachine _stateMachine;
    private ILoader _loader;
    private ScoreCounter _scoreCounter;
    private BallSpawner _ballSpawner;
    private ScoreWindow _scoreWindow;
    private LifeWindow _lifeWindow;
    private EventBus _eventBus;
    private GameConfig _gameConfig;

    public StartGameState(GameStateMachine stateMachine,
     ILoader loader,
      ScoreCounter scoreCounter,
      BallSpawner spawner,
      ScoreWindow scoreWindow,
      LifeWindow lifeWindow,
      EventBus eventBus,
      GameConfig gameConfig)
    {
        _stateMachine = stateMachine;
        _loader = loader;
        _scoreCounter = scoreCounter;
        _ballSpawner = spawner;
        _scoreWindow = scoreWindow;
        _lifeWindow = lifeWindow;
        _eventBus = eventBus;
        _gameConfig = gameConfig;
    }

    public void Enter()
    {
        LoadBestScore();
        _scoreCounter.ZeroScore();
        WindowsInit();
        SpawnerActivate();
        _stateMachine.SwitchState<GamePlayState>();
    }

    public void Exit()
    {

    }

    private void LoadBestScore()
    {
        GameData data = (GameData)_loader.Load();
        _scoreCounter.BestScore = data.Score;
    }

    private void SpawnerActivate()
    {
        _ballSpawner.StartSpawn();
    }

    private void WindowsInit()
    {
        _scoreWindow.Init(_scoreCounter, _eventBus);
        _lifeWindow.Init(_eventBus, _gameConfig);
    }
}
