using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeController : MonoBehaviourPunCallbacks
{
    
    public Camera secondPlayerCam;
    public Material selectedMaterial;

    private Material oldMaterial;
    private GameObject selectedCube;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = secondPlayerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.CompareTag("PuzzleCube") &&
                    hit.transform.GetComponent<CheckForPlayer>().cubeIsMoveable)
                {
                    if (selectedCube != null && selectedCube.GetComponent<CheckForPlayer>().cubeIsMoveable)
                    {
                        //save poisition of clicked cube
                        Vector3 position = hit.transform.position;
                        //setcolor to default
                        foreach (var meshRenderer in selectedCube.GetComponentsInChildren<MeshRenderer>())
                        {
                            meshRenderer.material = oldMaterial;
                        }
                        
                        //swaps position of clicked and selected
                        photonView.RPC("SwapPos",RpcTarget.All);

                        SwapPos(hit.transform,selectedCube.transform.position, position);
                   
                        
                        
                        //set bool of cube as Selected
                        selectedCube.GetComponent<CheckForPlayer>().isSelected = false;
                        
                        selectedCube = null;
                    }
                    //select new one
                    else
                    {
                        //get clicked cube
                        selectedCube = hit.transform.gameObject;
                        //Save defaultcolor
                        oldMaterial = selectedCube.GetComponentInChildren<MeshRenderer>().material;
                        //set bool of cube as Selected
                        selectedCube.GetComponent<CheckForPlayer>().isSelected = true;
                        //Color childs
                        foreach (var meshRenderer in selectedCube.GetComponentsInChildren<MeshRenderer>())
                        {
                            meshRenderer.material = selectedMaterial;
                        }
                    }
                }
            }
        }
    }
    
    [PunRPC]

    private void SwapPos(Transform gO, Vector3 transformPosition, Vector3 position)
    {
        gO.position = selectedCube.transform.position;
        selectedCube.transform.position = position;    }
}