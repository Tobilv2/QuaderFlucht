using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.Newtonsoft.Json.Serialization;

public class DoorManagerLevel12 : MonoBehaviour
{
    public enum DoorColors
    {
       Green,
       Yellow,
       Blue
    }
    
    
    public List<GameObject> greenDoors;
  

    public void Close(DoorColors col)
    {
        if (col == DoorColors.Green)
        {
            foreach (GameObject greenDoor in greenDoors)
            {
                greenDoor.GetComponent<DoorScriptLevel12>().ChangeState();
            }
        }
    }
    public void Open(DoorColors col)
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
