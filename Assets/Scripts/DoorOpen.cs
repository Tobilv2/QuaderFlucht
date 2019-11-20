using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animation>().Play("OpenDoor");
    }
}
