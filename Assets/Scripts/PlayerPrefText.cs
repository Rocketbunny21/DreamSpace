using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerPrefText : MonoBehaviour
{
    [FormerlySerializedAs("name")] public string naming;

    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(naming) + "";
    }
}
