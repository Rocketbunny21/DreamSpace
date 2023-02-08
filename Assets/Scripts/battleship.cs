using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleship : MonoBehaviour
{
    int delay = 0;
    public GameObject gun, gun1, gun2;
    public GameObject bullet, explosion;
    Rigidbody2D rb;
    public float speed;
    int health = 3;
    int scal = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        PlayerPrefs.SetInt("Health", health);
    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        if (Input.GetKey(KeyCode.Space) && delay > 15)
            Shoot();

        delay++;

    }
    public void Damage()
    {
        health--;
        PlayerPrefs.SetInt("Health", health);
        StartCoroutine(Blink());
        if (health == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
    void Shoot()
    {
        delay = 0;
        scal--;
        if (scal == 0||scal < 0)
        {
                Instantiate(bullet, gun.transform.position, Quaternion.identity);
        }

        if (scal > 0)
        {
                Instantiate(bullet, gun1.transform.position, Quaternion.identity);
                Instantiate(bullet, gun2.transform.position, Quaternion.identity);
        }
    }

    public void AddHealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }

    public void AddGun()
    {
        scal = 20;
    }
}
