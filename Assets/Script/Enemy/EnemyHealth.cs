using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 15f;
    public GameObject damageDisplay;
    
    public void ApplyDamage(float damage)
    {
        health -= damage;
        DisplayDamage(damage);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DisplayDamage(float damage)
    {
        GameObject display = Instantiate(damageDisplay, transform.position + new Vector3(0,1f,-1f), Quaternion.identity);
        display.transform.GetChild(0).SendMessage("ModifyDisplay", damage);
    }

}
