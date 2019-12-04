using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAttach : MonoBehaviour
{
    private GameObject VRPlayer;

    private void Start()
    {

        VRPlayer =  GameObject.FindGameObjectWithTag("VRPlayer");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == VRPlayer)
        {
            VRPlayer.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == VRPlayer)
        {
            VRPlayer.transform.parent = null;
        }
    }
}
