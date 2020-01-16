using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{

    private bool isBuildable;
    public bool IsBuildable
    {
        get { return isBuildable; }
        set
        {
            isBuildable = value;
            Color color = isBuildable ?  Color.green :  Color.red;
            GetComponentInChildren<MeshRenderer>().material.color = color;
        }
    }

    private void Start()
    {
        IsBuildable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
//        IsBuildable = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        IsBuildable = true;
    }
    
    
}