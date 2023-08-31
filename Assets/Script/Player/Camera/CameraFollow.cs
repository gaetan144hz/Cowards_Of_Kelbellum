using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject[] targets;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        GetTargets();
        if(targets.Length != 0)
        {
            Move();
        }
    }

    void GetTargets()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");
    }

    void Move()
    {
        if(targets != null) {
            Vector3 targetPosition = CalculateTargetPos() + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }    
    }

    Vector3 CalculateTargetPos()
    {
        Vector3 tp = new Vector3(0,0,0);

        foreach(GameObject g in targets)
        {
            tp += g.transform.position;
        }

        return tp / targets.Length;
    }

}
