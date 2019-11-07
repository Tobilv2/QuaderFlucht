using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private new Animation animation;
    private bool DoorIsOpen = false;

    private void Start()
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        if (!DoorIsOpen)
        {
            GetComponent<Animation>().Play("OpenDoor");
            DoorIsOpen = true;
        }
    } 
    
    public void CloseDoor()
    {
        if (DoorIsOpen)
        {
            GetComponent<Animation>().Play("CloseDor");
            DoorIsOpen = false;
        }
    }
}