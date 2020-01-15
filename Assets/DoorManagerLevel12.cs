using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagerLevel12 : MonoBehaviour
{
    public enum DoorColors
    {
       Green,
       Red,
       Yellow
       
    }
    public List<GameObject> greenDoors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeState(DoorColors.Green);
        }
    }

    public void ChangeState(DoorColors col)
    {
        if (col == DoorColors.Green)
        {
            foreach (GameObject greenDoor in greenDoors)
            {
                greenDoor.GetComponent<DoorScriptLevel12>().ChangeState();
            }
        }
    }
}
