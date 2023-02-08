using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlvl5 : MonoBehaviour
{
    public GameObject NextLevel;

    void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") > 20000)
        {
            NextLevel.SetActive(true);
        }
    }
}
