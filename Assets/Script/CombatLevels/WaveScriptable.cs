using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveScriptable", menuName = "CoK-Scritpables/WaveScriptable", order = 0)]
public class WaveScriptable : ScriptableObject 
{
    [SerializeField]
    public List<Wave> waves;
    
}


[System.Serializable]
public class Wave
{
    public List<EnemyWaveInfo> enemies;

    public Wave(EnemyWaveInfo enemies)
    {
        this.enemies.Add(enemies);
    }

}

[System.Serializable]
public class EnemyWaveInfo
{
    public GameObject enemyKind;
    public int amount;

    public EnemyWaveInfo(GameObject enemyKind, int amount)
    {
        this.enemyKind = enemyKind;
        this.amount = amount;
    }

}
