using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float enemySpeed = 1f;

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
        rb.velocity = (move * enemySpeed);
    }

}
