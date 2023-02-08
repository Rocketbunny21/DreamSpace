using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    public GameObject NextLevel;

    void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") > 5000)
        {
            NextLevel.SetActive(true);
        }
    }
}
