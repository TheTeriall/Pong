using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    public static GameManager Instance { get; private set; }

    public int winThreshold = 5;

    private int playerScore = 0;
    private int aiScore = 0;
    public event EventHandler OnScoreChanged;
    public event EventHandler OnBallSpawned;
    public event EventHandler OnGameEnded;
    public event EventHandler OnScored;
    private GameObject ball;
    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
        //Instantiate Ball and subscribe to events
        
    }

    private void Start()
    {
        SpawnBall();
    }

    private void SpawnBall()
    {
        ball = Instantiate(ballPrefab);
        Ball ballScript = ball.GetComponent<Ball>();
        ballScript.OnPlayerGoalEntered += Ball_OnPlayerGoalEntered;
        ballScript.OnAIGoalEntered += Ball_OnAIGoalEntered;
        OnBallSpawned?.Invoke(this, EventArgs.Empty);
    }

    private void Ball_OnAIGoalEntered(object sender, System.EventArgs e)
    {
        OnScored?.Invoke(this, EventArgs.Empty);
        playerScore++;
        if (playerScore >= winThreshold)
        {
            GameOver();
        }
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Player Scored");
        Destroy(ball);
        SpawnBall();
    }

    private void Ball_OnPlayerGoalEntered(object sender, System.EventArgs e)
    {
        OnScored?.Invoke(this, EventArgs.Empty);
        aiScore++;
        if (aiScore >= winThreshold)
        {
            GameOver();
        }
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("AI Scored");
        Destroy(ball);
        SpawnBall();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        OnGameEnded?.Invoke(this, EventArgs.Empty);
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public int GetAIScore()
    {
        return aiScore;
    }

    public GameObject GetBall()
    {
        return ball;
    }
}
