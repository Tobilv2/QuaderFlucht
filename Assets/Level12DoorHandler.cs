using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12DoorHandler : MonoBehaviour
{
    public DoorManagerLevel12 manager;

    public DoorManagerLevel12.DoorColors color;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OpenDoorButton"))
        {
            manager.Close(color);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("OpenDoorButton"))
        {
            manager.Close(color);
        }
    }
}
