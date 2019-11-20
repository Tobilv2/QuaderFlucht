using UnityEngine;

public class ButtonHandlerBridge : MonoBehaviour
{

    public Bridge bridge;
        
    private void OnTriggerExit(Collider other)
    {
            bridge.CloseDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        bridge.OpenDoor();
    }
}

