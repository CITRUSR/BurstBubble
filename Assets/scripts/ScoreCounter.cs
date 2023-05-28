using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreCounter
{
    public int Score { get; private set; }
    public int BestScore { get; set; }

    private EventBus _eventBus;

    public ScoreCounter(EventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public void AddScore(int scoreCount)
    {
        Score += scoreCount;
        _eventBus.Invoke(new ScoreChangedEvent(Score));
    }

    public void RemoveScore(int scoreCount)
    {
        Score -= scoreCount;
        _eventBus.Invoke(new ScoreChangedEvent(Score));
    }

    public void ZeroScore()
    {
        Score = 0;
        _eventBus.Invoke(new ScoreChangedEvent(Score));
    }
}
