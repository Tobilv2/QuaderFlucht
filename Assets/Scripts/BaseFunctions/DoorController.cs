using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private new Animation animation;
    private static bool OpenDoor;
    public GameObject Door;

    private void Start()
    {
        Door.GetComponent<Animation>().Play("CloseDoor");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("OpenDoorButton"))
        {
            Door.GetComponent<Animation>().Play("OpenDoor");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OpenDoorButton"))
        {
            Door.GetComponent<Animation>().Play("CloseDoor");
        }
    }
}