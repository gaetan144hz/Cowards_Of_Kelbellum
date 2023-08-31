using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 1f;
    public float attackDamage = 3f;

    public float knockbackDuration = 0.2f;
    public float knockbackDistance = 0.5f;

    public float teleportCooldown = 20f;
    public float escapeTeleportCooldown = 7f;
    private float lastTeleportTime;
    private float lastEscapeTeleportTime;


    [Header("AI Behavior")]
    public bool basicFollow = true;
    public bool teleport = false;
    public bool boss = false;

    [Header("Debug and Dev")]
    GameObject[] players;
    public GameObject closestPlayer;
    public GameObject closestEnemy;
    private float oldDistance = 9999;


    Rigidbody rb;

    private static readonly System.Random rnd = new System.Random();

    void Start()
    {
        rb  = this.GetComponent<Rigidbody>();
        
        lastTeleportTime = Time.time;
        lastEscapeTeleportTime = Time.time;

        transform.position += new Vector3(rnd.Next(0, 5), 0f, rnd.Next(0, 5));

        if(teleport)
        {
            RandomTeleport();
        }
    }

    void Update()
    {
        FindPlayer();
        if (closestPlayer != null)
        {
            if (basicFollow)
            {
                FollowPlayerBehavior();
            }
            if (teleport)
            {
                TeleportBehavior();
            }

        }
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

    void FindEnemy()
    {
        oldDistance = 9999;
        players = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in players)
        {
            float dist = Vector3.Distance(this.gameObject.transform.position, g.transform.position);
            if (dist < oldDistance)
            {
                closestEnemy = g;
                oldDistance = dist;
            }
        }
    }

    void FollowPlayerBehavior()
    {
        Vector3 lookAt = closestPlayer.transform.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void TeleportBehavior()
    {
        
        if (Time.time - lastEscapeTeleportTime > escapeTeleportCooldown)
        {
            if (Vector3.Distance(closestPlayer.transform.position, transform.position) < 5f)
            {
                lastEscapeTeleportTime = Time.time;
                RandomTeleport();
            }
        }

        if (Time.time - lastTeleportTime > teleportCooldown)
        {
            lastTeleportTime = Time.time;
            RandomTeleport();
        }
    }

    void RandomTeleport()
    {
        Debug.Log("Moved away");

        float randomX = Random.Range(0, Screen.width);
        float randomY = Random.Range(0, Screen.height);

        Vector3 randomPosition = new Vector3(randomX, randomY, 1f);
        randomPosition = Camera.main.ScreenToWorldPoint(randomPosition);

        transform.position = randomPosition;
    }


    public IEnumerator GetKnockback(Vector3 knockback)
    {
        float elapsedTime = 0f;
        Vector3 originalPosition = transform.position;

        while (elapsedTime < knockbackDuration)
        {
            float normalizedTime = elapsedTime / knockbackDuration;
            Vector3 knockbackOffset = knockback * knockbackDistance * normalizedTime;
            transform.position = originalPosition + knockbackOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerObjects")
        {
            collision.gameObject.transform.parent.gameObject.transform.parent.gameObject.SendMessage("ApplyDamage", attackDamage);
        }
    }

}
