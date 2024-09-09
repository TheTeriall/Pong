using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScore;
    [SerializeField] TextMeshProUGUI aiScore;
    [SerializeField] Button restartBtn;
    [SerializeField] Button quitBtn;
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
        GameManager.Instance.OnGameEnded += GameManager_OnGameEnded;
        playerScore.text = GameManager.Instance.GetPlayerScore().ToString();
        aiScore.text = GameManager.Instance.GetAIScore().ToString();
        restartBtn.onClick.AddListener(RestartBtn_OnClick);
        quitBtn.onClick.AddListener(QuitBtn_OnClick);
    }

    private void GameManager_OnGameEnded(object sender, System.EventArgs e)
    {
        gameOverCanvas.gameObject.SetActive(true);
    }

    private void GameManager_OnScoreChanged(object sender, System.EventArgs e)
    {
        playerScore.text = GameManager.Instance.GetPlayerScore().ToString();
        aiScore.text = GameManager.Instance.GetAIScore().ToString();
    }

    private void RestartBtn_OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void QuitBtn_OnClick()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
