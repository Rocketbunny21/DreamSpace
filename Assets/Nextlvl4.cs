using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlvl4 : MonoBehaviour
{
    public GameObject NextLevel;

    void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") > 15000)
        {
            NextLevel.SetActive(true);
        }
    }
}
