using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemyPrefab;

    public float spawnRate = 5f;
    public float lastSpawnTime = 5f;


    void Update()
    {
        if (Time.time - lastSpawnTime > spawnRate)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        lastSpawnTime = Time.time;
    }

}
