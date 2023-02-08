using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlvl3 : MonoBehaviour
{
    public GameObject NextLevel;

    void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") > 10000)
        {
            NextLevel.SetActive(true);
        }
    }
}
