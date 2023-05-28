using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultGame : IDifficultGame
{
    private BallConfig _ballConfig;
    private EventBus _eventBus;

    private float _difficult;

    public DifficultGame(BallConfig ballConfig, EventBus eventBus)
    {
        _ballConfig = ballConfig;
        _eventBus = eventBus;

        _eventBus.Subscribe<ScoreChangedEvent>(Difficulting);
    }

    private void OnDisable()
    {
        _eventBus.Unubscribe<ScoreChangedEvent>(Difficulting);
    }

    public void Difficulting(ScoreChangedEvent scoreChangedEvent)
    {
        if (scoreChangedEvent.Score % 5 == 0 && scoreChangedEvent.Score != 0)
        {
            _difficult++;
        }
    }

    public void BallRefresh(Ball ball)
    {
        ball.Parameters.LifeTime -= _difficult / 5;
        ball.Parameters.Size -= _difficult / 10;
        ball.Parameters.SpawnTime -= _difficult / 5;

        if (ball.Parameters.LifeTime <= 0.5)
            ball.Parameters.LifeTime = 0.5f;

        if (ball.Parameters.Size <= 0.2)
            ball.Parameters.Size = 0.2f;
    }
}
