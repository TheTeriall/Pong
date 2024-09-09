using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    public static GameManager Instance { get; private set; }

    private int playerScore = 0;
    private int aiScore = 0;
    public event EventHandler OnScoreChanged;
    public event EventHandler OnBallSpawned;
    private GameObject ball;
    private void Awake()
    {
        Instance = this;
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
        playerScore++;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Player Scored");
        SpawnBall();
    }

    private void Ball_OnPlayerGoalEntered(object sender, System.EventArgs e)
    {
        aiScore++;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("AI Scored");
        SpawnBall();
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
