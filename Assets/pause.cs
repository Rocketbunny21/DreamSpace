using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject menu;
    bool GameisPaused;
    public GameObject battleship, bullet;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
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
        battleship.GetComponent<battleship>().speed = 0;
        battleship.GetComponent<battleship>().bullet.SetActive(false);
        Time.timeScale = 0f;
        GameisPaused = true;
        
    }

    public void Continuebut()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        battleship.GetComponent<battleship>().speed = 9;
        battleship.GetComponent<battleship>().bullet.SetActive(true);
        GameisPaused = false;
    }
}
