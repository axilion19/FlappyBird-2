using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private float score;

    private void Awake() {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void Play(){
        score = 0;
        scoreText.text = score.ToString();
        
        GrowChall.growChallangeAccepted = false;
        GrowChall.growScore = 0f;
        GrowChall.growChallRate = 3f;

        DangerChall.dangerChallRate = 3f;
        DangerChall.dangerPipe = 3f;
        DangerChall.dangerScoring = 0f;
        DangerChall.dangerChallangeAccepted = false;
        
        HealthManager.health = 1;
        player.transform.position = Vector3.zero;

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause(){
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }
}
