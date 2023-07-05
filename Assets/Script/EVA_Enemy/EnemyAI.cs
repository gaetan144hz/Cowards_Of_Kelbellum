using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float enemySpeed = 1f;
    public float attackDamage = 3f;

    GameObject[] players;
    public GameObject closestPlayer;
    private float oldDistance = 9999;  

    Rigidbody rb;

    void Start()
    {
        rb  = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        FindPlayer();
        Move();
    }

    void FindPlayer()
    {
        oldDistance = 9999;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in players)
        {
            float dist = Vector3.Distance(this.gameObject.transform.position, g.transform.position);
            if (dist < oldDistance)
            {
                closestPlayer = g;
                oldDistance = dist;
            }
        }
    }

    void Move()
    {
        Vector3 move = (closestPlayer.transform.position - transform.position);
        move.Normalize();
        move.y = 0;
        rb.velocity = (move * enemySpeed);
    }

    public void GetKnockback(Vector3 knockback)
    {
        knockback.y = 0.05f;
        transform.position = transform.position + knockback;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerObjects")
        {
            collision.gameObject.transform.parent.gameObject.transform.parent.gameObject.SendMessage("ApplyDamage", attackDamage);
        }
    }

}
