using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LifeCounter
{
    public int Life { get; private set; }

    private GameConfig _gameConfig;
    private EventBus _eventBus;

    public LifeCounter(GameConfig gameConfig, EventBus eventBus)
    {
        _gameConfig = gameConfig;
        _eventBus = eventBus;

        Life = _gameConfig.Life;
    }

    public void RemoveLife(int count)
    {
        Life -= count;
        _eventBus.Invoke(new LifeChangedEvent(Life));
        if (Life <= 0)
        {
            _eventBus.Invoke(new LoseEvent());
        }
    }
}
