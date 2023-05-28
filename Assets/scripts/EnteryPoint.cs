using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteryPoint : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private BallConfig _ballConfig;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private ScoreWindow _scoreWindow;
    [SerializeField] private LifeWindow _lifeWindow;
    [SerializeField] private LoseWindow _loseWindow;
    [SerializeField] private string _fileSavePath;

    private GameStateMachine _stateMachine;
    private EventBus _eventBus;

    private void Start()
    {
        _eventBus = new EventBus();

        ScoreCounter scoreCounter = new ScoreCounter(_eventBus);
        LifeCounter LifeCounter = new LifeCounter(_gameConfig, _eventBus);

        BallDestroyer destroyer = new BallDestroyer();

        IDifficultGame difficultGame = new DifficultGame(_ballConfig, _eventBus);

        BallFactory ballFactory = new BallFactory(_ballConfig, scoreCounter, LifeCounter, difficultGame, destroyer);

        BallPositionFinder ballPositionFinder = new BallPositionFinder(_camera);

        BallSpawner ballSpawner = new BallSpawner(ballFactory, _ballConfig, ballPositionFinder);

        ISaver saver = new BinSaver(_fileSavePath);
        ILoader loader = new BinLoader(_fileSavePath);

        _stateMachine = new GameStateMachine();

        _stateMachine.AddState(new StartGameState(_stateMachine, loader, scoreCounter, ballSpawner, _scoreWindow, _lifeWindow, _eventBus, _gameConfig));
        _stateMachine.AddState(new GamePlayState(_stateMachine, destroyer, _eventBus));
        _stateMachine.AddState(new EndGameState(_stateMachine, ballSpawner, saver, loader, scoreCounter, _loseWindow));

        _stateMachine.SwitchState<StartGameState>();
    }
}
