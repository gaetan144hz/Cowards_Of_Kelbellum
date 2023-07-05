using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    
    public float damage = 10f;
    public float range = 2f;
    public float attackArea = 45f;
    public float knockbackForce = 3f;

    GameObject[] enemies;


    // init

    private void Start() {
    }

    private float CalculateDamage()
    {
        return damage;
    }

    // Attack Loop

    public void Attack()
    {
        UpdateEnemyList();
        EnemiesHit();
    }

    private void UpdateEnemyList()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }   

    private void EnemiesHit()
    {
        foreach (GameObject g in enemies)
        {
            float dist = Vector3.Distance(this.gameObject.transform.position, g.transform.position);
            float dotProduct = Vector3.Dot(g.transform.position - this.gameObject.transform.position, transform.rotation * Vector3.forward);

            if (dist < range && dotProduct > 0.5f)
            {
                Hit(g);
            }
        }
    }

    private void Hit(GameObject g)
    {

        g.SendMessage("ApplyDamage", CalculateDamage());

        Vector3 knockback = Vector3.Normalize(g.transform.position - this.gameObject.transform.position);
        g.SendMessage("GetKnockback", knockback * knockbackForce);

    }

}
