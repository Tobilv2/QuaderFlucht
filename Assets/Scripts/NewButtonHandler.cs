using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NewButtonHandler : MonoBehaviourPunCallbacks
{
    public bool isInteractableCubeSpawner;
    public bool isMetalCubeSpawner;
    public bool isDoorOpener;
    public bool isFloorReseter;
    public bool isFloorMaxCountSizer;

    public GameObject metalCube;
    public Transform spawnPoint;
    public GameObject cube;

    private int placeAbleFloors = 3;
    public BuildController buildController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OpenDoorButton"))
        {
            if (isMetalCubeSpawner)
            {
                photonView.RPC("SetCubeActive",RpcTarget.All);
            }
            
            if (isFloorMaxCountSizer)
            {
                placeAbleFloors = 5;
                photonView.RPC("SetPlacedAbleFloors",RpcTarget.All);

            }
        }

        if (other.CompareTag("Metal"))
        {
            if (isFloorReseter)
            {
                cube = other.gameObject;

               photonView.RPC("FloorResetter",RpcTarget.All);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OpenDoorButton"))
        {
            if (isMetalCubeSpawner)
            {
                photonView.RPC("SetCubeActive",RpcTarget.All);
                
            }
            
            if (isFloorMaxCountSizer)
            {
                placeAbleFloors = 2;
                photonView.RPC("SetPlacedAbleFloors",RpcTarget.All);

            }
        }

    }

    [PunRPC]
    void FloorResetter()
    {
        print("ok");
     //   cube.transform.position = spawnPoint.position;
     //   buildController.RemoveAllFloors();
    }
    
    

    [PunRPC]
    void SetCubeInActive()
    {
        metalCube.SetActive(false);
    } 
    
    [PunRPC]
    void SetCubeActive()
    {
        metalCube.SetActive(true);
        metalCube.transform.position = spawnPoint.position;
    }

    [PunRPC]
    void SetPlacedAbleFloors()
    {
        buildController.maxPlaceAbleFloors = placeAbleFloors;
        buildController.FloorsLeftTextUpdater();
    }
}