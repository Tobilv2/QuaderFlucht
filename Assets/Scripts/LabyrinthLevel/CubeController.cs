using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeController : MonoBehaviourPunCallbacks
{
    
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
            Camera cam = GameObject.FindWithTag("MobilePlayer").GetComponentInChildren<Camera>();

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
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
                        
                    
                        photonView.RPC("SwapPos",RpcTarget.All,hit.transform,selectedCube,position);

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
    //swaps position of clicked and selected
    void SwapPos(Transform hitTransform,GameObject selectedCube ,Vector3 position)
    {
        hitTransform.position = selectedCube.transform.position;
        selectedCube.transform.position = position;

    }
}