using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class DeathManager : MonoBehaviour
{
    GameObject _player;
     bool _gameOver = false;
    public GameObject gameCanvas;
    public GameObject gameOverCanvas;
    public int scene;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //if (player == null&&!gameOver)
           // GameOver();
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        _gameOver = true;
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
