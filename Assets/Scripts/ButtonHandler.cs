using UnityEngine;

    public class ButtonHandler : MonoBehaviour
    {

        public Door door;
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("OpenDoorButton"))
            {
                door.CloseDoor();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("OpenDoorButton"))
            {
                door.OpenDoor();
            }
        }
    }