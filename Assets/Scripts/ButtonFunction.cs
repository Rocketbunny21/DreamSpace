using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Start()
    {
        SceneManager.LoadScene(1);
    }
}

