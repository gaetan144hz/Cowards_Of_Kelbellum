using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMat : MonoBehaviour
{

    public GameObject[] selected;


    public void SwitchMaterial(Material mat)
    {
        foreach(GameObject g in selected)
        {
            g.GetComponent<MeshRenderer>().material = mat;
        }
    }

}
