using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRedTarget : MonoBehaviour
{
    private bool red = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            red = true;
        }

    }
    public bool GetRed()
    {
        return red;
    }
}
