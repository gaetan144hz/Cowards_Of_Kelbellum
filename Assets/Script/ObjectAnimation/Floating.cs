using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{

    [Header("Settings")]
    public bool floating = true;
    
    public float distance = 0.5f;
    public float speed = 1f;

    private Vector3 tempPos;
    private float y0;


    void Start()
    {
        y0 = transform.position.y;
    }

    void Update()
    {
        tempPos = transform.position;
        tempPos.y = y0 + Mathf.Sin (Time.fixedTime * Mathf.PI * speed) * distance;
        transform.position = tempPos;
    }
}
