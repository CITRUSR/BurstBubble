using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory : GenericFactory<Ball>
{
    private BallConfig _ballConfig;
    private ScoreCounter _scoreCounter;
    private LifeCounter _lifeCounter;
    private IDifficultGame _difficultGame;
    private BallDestroyer _ballDestoryer;

    public BallFactory(BallConfig BallConfig,
     ScoreCounter ScoreCounter,
      LifeCounter lifeCounter,
       IDifficultGame difficultGame,
       BallDestroyer ballDestroyer)
    {
        _prefab = BallConfig.BallPrefab;
        _ballConfig = BallConfig;
        _scoreCounter = ScoreCounter;
        _lifeCounter = lifeCounter;
        _difficultGame = difficultGame;
        _ballDestoryer = ballDestroyer;
    }

    public override Ball Create(Vector2 pos)
    {
        Ball ball = base.Create(pos);
        _difficultGame.BallRefresh(ball);
        ball.Init(_scoreCounter, _lifeCounter, _ballDestoryer);

        return ball;
    }
}
