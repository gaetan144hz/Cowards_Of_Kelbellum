using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{

    public float damage = 10f;

    public bool showProjectile = false;
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;

    GameObject[] enemies;
    public GameObject closestEnemy;
    private float oldDistance = 9999;  

    Camera cam;

    void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
    }

    public void Attack()
    {
        UpdateEnemyList();
        FindNearestEnemy();
        if (showProjectile)
        {
                Fire();
        }
    }

    private void UpdateEnemyList()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void FindNearestEnemy()
    {
        oldDistance = 9999;
        foreach (GameObject g in enemies)
        {
            float dist = Vector3.Distance(this.gameObject.transform.position, g.transform.position);
            if (dist < oldDistance)
            {
                closestEnemy = g;   
                oldDistance = dist;
            }

            if (closestEnemy != null)
            {
                Vector3 viewPos = cam.WorldToViewportPoint(closestEnemy.transform.position);
                if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
                {
                }
                else
                {
                    closestEnemy = null;
                }
            }
        }
    }

    private void Fire()
    {
        GameObject shot = Instantiate(projectilePrefab, transform.position + (transform.rotation * Vector3.forward) , transform.rotation);
        Rigidbody rb = shot.GetComponent<Rigidbody>();

        
        Vector3 aimVector = (transform.rotation * Vector3.forward);

        if (closestEnemy)
        {
            
            Rigidbody closestRb = closestEnemy.GetComponent<Rigidbody>();
            Vector3 enemyVector = Vector3.Normalize(closestEnemy.transform.position - (transform.position + transform.rotation * Vector3.forward));
            if (Vector3.Dot(enemyVector, aimVector) > 0.5f)
            {
                rb.velocity = enemyVector * projectileSpeed;
            }   
            else
            { 
                rb.velocity = aimVector * projectileSpeed;
            }
        }
        else
        {
            rb.velocity = aimVector * projectileSpeed;
        }

        shot.transform.rotation = Quaternion.LookRotation(rb.velocity);

        shot.SendMessage("CarryDamage", CalculateDamage());

    }

    private float CalculateDamage()
    {
        return damage;
    }

}
