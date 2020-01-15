using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRedTarget : MonoBehaviour
{
    public bool red = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            red = true;
        }

    }
}
