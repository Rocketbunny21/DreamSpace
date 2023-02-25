using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    GameObject player;
    bool gameOver = false;
    public GameObject GameCanvas;
    public GameObject GameOverCanvas;
    public int scene;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null&&!gameOver)
            GameOver();
    }

    void GameOver()
    {
        GameOverCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        gameOver = true;
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Score", 0);
        GameOverCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        SceneManager.LoadScene(1);
    }
    
}
