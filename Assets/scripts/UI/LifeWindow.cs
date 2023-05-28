using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeWindow : Window
{
    [SerializeField] TextMeshProUGUI _lifeText;
    private EventBus _eventBus;
    private GameConfig _gameConfig;

    public void Init(EventBus eventBus, GameConfig gameConfig)
    {
        _eventBus = eventBus;
        _gameConfig = gameConfig;

        _eventBus.Subscribe<LifeChangedEvent>(RefreshText);

        _lifeText.text = "Life:" + _gameConfig.Life;
    }

    private void OnDisable()
    {
        _eventBus.Unubscribe<LifeChangedEvent>(RefreshText);
    }

    public void RefreshText(LifeChangedEvent lifeChanged)
    {
        _lifeText.text = "Life:" + lifeChanged.Life;
    }
}
