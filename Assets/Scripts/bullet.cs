using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D _rb;
    int _dir = 1;
    private SpriteRenderer _spRender;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spRender = GetComponent<SpriteRenderer>();
    }

    public void ChangeDirection()
    {
        _dir *= -1;
    }

    public void ChangeColor(Color col)
    {
        _spRender.color = col;
    }

    void Update()
    {
        _rb.velocity = new Vector2(0,12 * _dir);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_dir == 1)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }
        }
        else
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<battleship>().Damage();
                Destroy(gameObject);                            
            }
        }
        
    }
}
