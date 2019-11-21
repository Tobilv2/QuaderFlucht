using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animation door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("OpenDoorButton"))
        door.Play("OpenDoor");
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("OpenDoorButton"))
        door.Play("CloseDoor");
    }
}
