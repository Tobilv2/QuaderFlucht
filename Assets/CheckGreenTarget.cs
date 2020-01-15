using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGreenTarget : MonoBehaviour
{
    private bool green = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Green")
        {
            this.green = true;
        }

    }

    public bool GetGreen()
    {
        return green;
    }
}
