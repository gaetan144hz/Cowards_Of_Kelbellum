using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float destroyDelay = 8f;

    public bool destroyOnInstantiate = true;
    public bool destroyOnHit = true;

    private Rigidbody rb;

    public float attackDamage;

    void Start()
    {
        if (destroyOnInstantiate) {
            DestroyOnTime();
        }

        rb = GetComponent<Rigidbody>();
    }

    public void DestroyOnTime()
    {
        Destroy(gameObject, destroyDelay);
    }

    public void CarryDamage(float damage)
    {
        attackDamage = damage;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamage", attackDamage);
            Destroy(gameObject, 0f);
        }
        if (collision.gameObject.tag != "Player")
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }


}
