using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPinkTarget : MonoBehaviour
{
    public bool pink = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pink")
        {
            this.pink = true;
        }

    }
}
