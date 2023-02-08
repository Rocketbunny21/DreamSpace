using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void lvl2()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(3);
    }
    public void lvl3()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(4);
    }
    public void lvl4()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(5);
    }
    public void lvl5()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(6);
    }
}
