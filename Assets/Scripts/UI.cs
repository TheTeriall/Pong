using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScore;
    [SerializeField] TextMeshProUGUI aiScore;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
        playerScore.text = GameManager.Instance.GetPlayerScore().ToString();
        aiScore.text = GameManager.Instance.GetAIScore().ToString();
    }

    private void GameManager_OnScoreChanged(object sender, System.EventArgs e)
    {
        playerScore.text = GameManager.Instance.GetPlayerScore().ToString();
        aiScore.text = GameManager.Instance.GetAIScore().ToString();
    }
}
