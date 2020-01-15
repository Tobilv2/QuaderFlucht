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
       Blue,
       Black
    }
    
    
    public List<GameObject> greenDoors;
    public List<GameObject> yellowDoors;
    public List<GameObject> blueDoors;
    public List<GameObject> blackDoors;
  

    public void Close(DoorColors col)
    {
        if (col == DoorColors.Green)
        {
            foreach (GameObject greenDoor in greenDoors)
            {
                greenDoor.GetComponent<DoorScriptLevel12>().ChangeState();
            }
        }
        if (col == DoorColors.Yellow)
        {
            foreach (GameObject yellowDoor in yellowDoors)
            {
                yellowDoor.GetComponent<DoorScriptLevel12>().ChangeState();
            }
        }
        if (col == DoorColors.Blue)
        {
            foreach (GameObject blueDoor in blueDoors)
            {
                blueDoor.GetComponent<DoorScriptLevel12>().ChangeState();
            }
        }
        if (col == DoorColors.Black)
        {
            foreach (GameObject blackDoor in blackDoors)
            {
                blackDoor.GetComponent<DoorScriptLevel12>().ChangeState();
            }
        }
    }

    

}
