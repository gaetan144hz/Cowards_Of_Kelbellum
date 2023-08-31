using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemyPrefab;

    public float spawnRate = 5f;
    public float lastSpawnTime = 5f;
    public int enemySpawned = 0;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnRate)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        var spawned = Instantiate(enemyPrefab, transform.position, transform.rotation);
        if (enemySpawned % 16 == 15)
        {
            spawned.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            spawned.SendMessage("ApplyDamage", -150f);
        }
        enemySpawned += 1;
        lastSpawnTime = Time.time;
    }

}
