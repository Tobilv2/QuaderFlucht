using UnityEngine;

public class ButtonHandlerBridge : MonoBehaviour
{

    public Bridge bridge;
        
    private void OnTriggerExit(Collider other)
    {

        //if (other.CompareTag("OpenDoorButton"))
        //{
        //    bridge.RetractBridge();
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OpenDoorButton"))
        {
            bridge.ExtendBridge();
        }
    }
}

