using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.Instance.OnScored += GameManager_OnScored; ;
    }

    private void GameManager_OnScored(object sender, System.EventArgs e)
    {
        audioSource.Play();
    }
}
