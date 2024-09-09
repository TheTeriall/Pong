using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayButton_OnClick);
        quitButton.onClick.AddListener(QuitButton_OnClick);
    }

    private void PlayButton_OnClick()
    {
        // Load game scene
        SceneManager.LoadScene("GameScene");
    }

    private void QuitButton_OnClick()
    {
        Application.Quit();
    }


}
