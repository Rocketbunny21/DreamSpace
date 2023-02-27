using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class battleship : MonoBehaviour
{
    int _delay = 0;
    public GameObject gun, gun1, gun2;
    public GameObject bullet, explosion;
    Rigidbody2D rb;
    [SerializeField] private DeathManager deathManager;
    public float speed;
    int _health = 3;
    int _scal = 0;
    private SpriteRenderer _spriteShip;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteShip = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        PlayerPrefs.SetInt("Health", _health);
    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        if (Input.GetKey(KeyCode.Space) && _delay > 15)
            Shoot();

        _delay++;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        // case: Enemy, DoubleGun, Heal and other;
        
        if (CompareTag("Enemy"))
        {
            Damage();
            col.gameObject.GetComponent<Enemy>().Die();
        }
    }
    

    public void Damage()
    {
        _health--;
        PlayerPrefs.SetInt("Health", _health);
        StartCoroutine(Blink());
        if (_health == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
            deathManager.GameOver();
        }
    }

    IEnumerator Blink()
    {
        _spriteShip.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteShip.color = Color.white;
    }
    void Shoot()
    {
        _delay = 0;
        _scal--;
        if (_scal == 0 || _scal < 0)
        {
                Instantiate(bullet, gun.transform.position, Quaternion.identity);
        }

        if (_scal > 0)
        {
                Instantiate(bullet, gun1.transform.position, Quaternion.identity);
                Instantiate(bullet, gun2.transform.position, Quaternion.identity);
        }
    }

    public void AddHealth()
    {
        _health++;
        PlayerPrefs.SetInt("Health", _health);
    }

    public void AddGun()
    {
        _scal = 20;
    }
}
