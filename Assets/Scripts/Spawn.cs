using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public float rate;
    public GameObject[] enemies;
    public int waves = 1;
    [SerializeField] private List<float> _bitRate;
    private int _countBit = 0;

    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    [SerializeField] private float songBpm;

    //The number of seconds for each song beat
    [SerializeField] private float secPerBeat;

    //Current song position, in seconds
    [SerializeField] private float songPosition;

    //Current song position, in beats
    [SerializeField] private float songPositionInBeats;

    //How many seconds have passed since the song started
    [SerializeField] private float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    [SerializeField] private AudioSource musicSource;
    
    [SerializeField] private float firstBeatOffset;
    
    
    private void Start()
    {
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = (60f / songBpm)*2;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
        
        StartCoroutine(BitSpawn());
        
    }

    public void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
    }

    private IEnumerator BitSpawn()
    {
        yield return new WaitForSeconds(secPerBeat);
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
