using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerPrefText : MonoBehaviour
{
    [FormerlySerializedAs("name")] public string naming;
    [SerializeField] private Text textHealth;

    void Update()
    {
        textHealth.text = PlayerPrefs.GetInt(naming) + "";
    }
}
