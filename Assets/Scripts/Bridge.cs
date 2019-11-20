using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private new Animation animation;
    private bool BridgeIsOpen;

    private void Start()
    {

        BridgeIsOpen = true;
        
    }

    public void OpenDoor()
    {
        if (!BridgeIsOpen)
        {
            GetComponent<Animation>().Play("BridgeAnimation");
            BridgeIsOpen = true;
        }
    } 
    
    public void CloseDoor()
    {
        if (BridgeIsOpen)
        {
//            GetComponent<Animation>().Play("CloseDoor");
            BridgeIsOpen = false;
        }
    }
}