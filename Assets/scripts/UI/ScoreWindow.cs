using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreWindow : Window
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreBestText;

    private ScoreCounter _scoreCounter;
    private EventBus _eventBus;

    private void OnDisable()
    {
        _eventBus.Unubscribe<ScoreChangedEvent>(RefreshText);
    }

    public void Init(ScoreCounter scoreCounter, EventBus eventBus)
    {
        _scoreCounter = scoreCounter;
        _eventBus = eventBus;
        _eventBus.Subscribe<ScoreChangedEvent>(RefreshText);
        _scoreBestText.text = "Best Score:" + _scoreCounter.BestScore.ToString();
    }

    private void RefreshText(ScoreChangedEvent scoreChangedEvent)
    {
        _scoreText.text = "Current Score:" + _scoreCounter.Score.ToString();
    }
}
