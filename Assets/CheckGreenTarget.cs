using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGreenTarget : MonoBehaviour
{
    public bool green = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Green")
        {
            this.green = true;
        }

    }
}
