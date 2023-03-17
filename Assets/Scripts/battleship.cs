using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class battleship : MonoBehaviour
{
    [SerializeField] private DeathManager deathManager;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] public float speed;

    private float _acceleration;
    
    int _delay = 0;
    int _health = 3;
    int _scal = 0;
    
    public GameObject gun, gun1, gun2;
    public GameObject bullet, explosion;
    
    Rigidbody2D rb;
    
    
    
    
    private SpriteRenderer _spriteShip;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteShip = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Health", _health);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            InvokeRepeating(nameof(Shoot),fireRate,fireRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
            CancelInvoke(nameof(Shoot));
        }
    }


    private void FixedUpdate()
    {
        Control();

    }


    // ReSharper disable Unity.PerformanceAnalysis
    private void Control()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        
        
        
            

        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag){
            case "Health":
                AddHealth();
                Destroy(col.gameObject);
                break;
            case "DoubleDamage":
                AddGun();
                Destroy(col.gameObject);
                break;

        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
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
