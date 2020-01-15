using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckYellowTarget : MonoBehaviour
{
    private bool yellow = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Yellow")
        {
            this.yellow = true;
        }

    }
    public bool GetYellow()
    {
        return yellow;
    }
}
