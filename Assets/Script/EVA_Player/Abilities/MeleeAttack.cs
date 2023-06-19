using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    
    public float damage = 10f;
    public float range = 1f;
    public float attackSpeed = 1f;

    public void Attack()
    {
        Debug.Log("ATTACKED");
    }

}
