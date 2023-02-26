using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject menu;
    bool _gameisPaused;
    public GameObject battleship, bullet;
    private battleship _bShip;


    private void Start()
    {
        _bShip = battleship.GetComponent<battleship>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameisPaused)
            {
                Continuebut();
            }
            else
            {
                Pause();
            }

        }

    }

    public void Pause()
    {
        
        menu.SetActive(true);
        _bShip.speed = 0;
        _bShip.bullet.SetActive(false);
        Time.timeScale = 0f;
        _gameisPaused = true;
        
    }

    public void Continuebut()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        _bShip.speed = 5;
        _bShip.bullet.SetActive(true);
        _gameisPaused = false;
    }
}
