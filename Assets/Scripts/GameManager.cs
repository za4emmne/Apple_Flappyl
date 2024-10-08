using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private EnemyGenerator _enemyGeneration;

    private void OnEnable()
    {
        _bird.GameOver += OnGameOver;
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _bird.GameOver -= OnGameOver;
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        StartGame();
    }

    private void StartGame()
    {
        _pipeGenerator.StartPlay();
        _enemyGeneration.StartPlay();
        Time.timeScale = 1; 
        _startScreen.Close();
        _bird.Reset();
    }
}
