using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeController : MonoBehaviour
{
    public GameObject VRPlayerForTesting;
    public float speed;

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
        #region Testing

        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float z = Input.GetAxis("Vertical") * speed;
        float x = Input.GetAxis("Horizontal") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        x *= Time.deltaTime;
        z *= Time.deltaTime;

        // Move translation along the object's z-axis
        VRPlayerForTesting.transform.Translate(x, 0, z);

        // Rotate around our y-axis

        #endregion

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
                        //swaps position of clicked and selected
                        hit.transform.position = selectedCube.transform.position;
                        selectedCube.transform.position = position;
                        //setcolor to default
                        foreach (var meshRenderer in selectedCube.GetComponentsInChildren<MeshRenderer>())
                        {
                            meshRenderer.material = oldMaterial;
                        }
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
}