using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoseWindow : Window
{
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    private GameStateMachine _stateMachine;
    private ScoreCounter _scoreCounter;
    private ILoader _loader;

    private int _bestScore;

    public void Init(GameStateMachine stateMachine, ScoreCounter scoreCounter, ILoader loader)
    {
        ShowWindow();

        _stateMachine = stateMachine;
        _scoreCounter = scoreCounter;
        _loader = loader;

        LoadScore();

        _bestScoreText.text = "Best Score:" + _bestScore;
        _currentScoreText.text = "Current Score:" + _scoreCounter.Score;
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadScore()
    {
        GameData data = (GameData)_loader.Load();
        _bestScore = data.Score;
    }
}
