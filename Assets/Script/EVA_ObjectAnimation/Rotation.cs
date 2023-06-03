using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    [Header("Settings")]
    public bool rotating = true;
    public bool clockwise = true;
    [Space(5)]
    public Vector3 rotationVector;

    void Update()
    {

        if (!clockwise) 
        {
            rotationVector = rotationVector * -1;
        }        
        if (rotating)
        {
            transform.Rotate(rotationVector * Time.deltaTime);
        }
    }
}
