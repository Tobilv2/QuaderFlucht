using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{

    public bool isBuildable;


    private void OnTriggerEnter(Collider other)
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        isBuildable = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        isBuildable = true;
    }
    
}