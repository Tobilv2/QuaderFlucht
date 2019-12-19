using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewButtonHandler : MonoBehaviour
{
    public bool isInteractableCubeSpawner;
    public bool isMetalCubeSpawner;
    public bool isDoorOpener;
    public bool isFloorReseter;
    public bool isFloorMaxCountSizer;

    public GameObject metalCube;
    public Transform spawnPoint;

    public BuildController buildController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OpenDoorButton"))
        {
            if (isMetalCubeSpawner)
            {
                metalCube.SetActive(true);
                metalCube.transform.position = spawnPoint.position;
            }
            
            if (isFloorMaxCountSizer)
            {
                buildController.maxPlaceAbleFloors = 5;
                buildController.FloorsLeftTextUpdater();
            }
        }

        if (other.CompareTag("Metal"))
        {
            if (isFloorReseter)
            {
                other.transform.position = spawnPoint.position;
                buildController.RemoveAllFloors();
            }
        }

   
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OpenDoorButton"))
        {
            if (isMetalCubeSpawner)
            {
                metalCube.SetActive(false);
            }
            
            if (isFloorMaxCountSizer)
            {
                buildController.maxPlaceAbleFloors = 2;
                buildController.FloorsLeftTextUpdater();
            }
        }

    }
}