using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlayer : MonoBehaviour
{
    public bool isSelected = false;
    public Material unableToSelect;
    public Material mouseOverMaterial;
    
    public bool cubeIsMoveable;
    
    private Material oldMaterial;
    private Material currentMaterial;

    private void Start()
    {
        cubeIsMoveable = true;
        oldMaterial = GetComponentInChildren<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cubeIsMoveable = false;
            foreach (var meshRenderer in GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.material = unableToSelect;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cubeIsMoveable = true;
            foreach (var meshRenderer in GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.material = oldMaterial;
            }
        }
    }

    private void OnMouseEnter()
    {
        if (cubeIsMoveable && !isSelected)
        {
            foreach (var meshRenderer in GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.material = mouseOverMaterial;
            }
        }
    }

    private void OnMouseExit()
    {
        if (cubeIsMoveable && !isSelected)
        {
            foreach (var meshRenderer in GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.material = oldMaterial;
            }
        }
    }
}