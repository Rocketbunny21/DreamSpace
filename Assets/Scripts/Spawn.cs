using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float rate;
    public GameObject[] enemies;
    public int waves = 1;
    [SerializeField] private List<float> _bitRate;
    private int _countBit = 0;

    private void Start()
    {
        StartCoroutine(BitSpawn());
        //InvokeRepeating("SpawnEnemy", rate, rate);
    }

    private IEnumerator BitSpawn()
    {
        yield return new WaitForSeconds(_bitRate[_countBit]);
        Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-8.5f, 8.5f), 7, 0), Quaternion.identity); 
        
        
        
        _countBit++;
        if (_countBit >= _bitRate.Count) _countBit = 0;
    
        StartCoroutine(BitSpawn());
    }
    
    
    // void SpawnEnemy()
    // {
    //     for(int i=0; i<waves;i++)
    //         Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-8.5f, 8.5f), 7, 0), Quaternion.identity);
    // }
}
