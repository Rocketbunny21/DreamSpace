using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<battleship>().AddGun();
            Destroy(gameObject);
        }
    }
}