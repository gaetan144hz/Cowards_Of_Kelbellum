using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 50f;
    
    public void ApplyDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
