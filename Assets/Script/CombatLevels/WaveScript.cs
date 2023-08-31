using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    [Header("Waves Settings")]
    public float timeBeforeFirstWave = 10f;
    public float timeBetweenWaves = 15f;

    public float spawnCooldown = 1f;

    public int currentWave;

    public WaveScriptable waveData;

    private float lastRegisteredTime;

    [Header("Wave Spawn Origins")]
    public GameObject[] spawners;


    private static readonly System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        lastRegisteredTime = Time.time;
        currentWave = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWave == -1)
        {
            if (Time.time - lastRegisteredTime > timeBeforeFirstWave)
            {
                lastRegisteredTime = Time.time;
                NextWave();
            }
        }
        else if (Time.time - lastRegisteredTime > timeBetweenWaves)
        {
            lastRegisteredTime = Time.time;
            NextWave();
        }
    }

    void NextWave()
    {        
        currentWave += 1;
        LaunchWave();
    }

    void LaunchWave()
    {
        if (currentWave > waveData.waves.Count - 1)
        {
            return;
        }
        SpawnWaves();
    }

    void SpawnWaves()
    {
        foreach (EnemyWaveInfo eWI in waveData.waves[currentWave].enemies)
        {
            Debug.Log("Wave " + currentWave + " | " + eWI.amount + " * " + eWI.enemyKind);
            SpawnEnemies(eWI);
        }
    }

    void SpawnEnemies(EnemyWaveInfo eWI)
    {
        int enemiesLeft = eWI.amount;

        while (enemiesLeft != 0)
        {
            Instantiate(eWI.enemyKind, spawners[rnd.Next(0, spawners.Length)].transform);

            enemiesLeft -= 1;
        }
    }
}
