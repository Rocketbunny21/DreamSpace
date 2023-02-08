using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDel : MonoBehaviour
{
    public GameObject Image, Image1, Image2,Image3, Text2lvl, Text3lvl, Text4lvl, Text5lvl;

    void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") > 5000)
        {
            Destroy(Image);
            Destroy(Text2lvl);
            Text3lvl.SetActive(true);
        }
        if (PlayerPrefs.GetInt("HighScore") > 10000)
        {
            Destroy(Image1);
            Destroy(Text3lvl);
            Text4lvl.SetActive(true);
        }
        if (PlayerPrefs.GetInt("HighScore") > 15000)
        {
            Destroy(Image2);
            Destroy(Text4lvl);
            Text5lvl.SetActive(true);
        }
        if (PlayerPrefs.GetInt("HighScore") > 20000)
        {
            Destroy(Image3);
            Destroy(Text5lvl);
        }
    }
}
