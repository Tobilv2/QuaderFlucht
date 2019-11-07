using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private new Animation animation;
    private bool DoorIsOpen;

    private void Start()
    {
        CloseDoor();
    }

    private void OpenDoor()
    {
        if (!DoorIsOpen)
        {
            GetComponent<Animation>().Play("OpenDoor");
            DoorIsOpen = true;
        }
    } 
    
    private void CloseDoor()
    {
        if (DoorIsOpen)
        {
            GetComponent<Animation>().Play("CloseDor");
            DoorIsOpen = false;
        }
    }
}