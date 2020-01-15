using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptLevel12 : MonoBehaviour
{
    public bool isClosed = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animation>().Play("CloseDoorTobi");
    }

    // Update is called once per frame
    public void ChangeState()
    {
        if (isClosed)
        {
            gameObject.GetComponent<Animation>().Play("OpenDoorTobi");
            isClosed = false;
        }
        else
        {
            gameObject.GetComponent<Animation>().Play("CloseDoorTobi");
            isClosed = true;
        }
    }
}
