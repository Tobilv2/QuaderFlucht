using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Build : MonoBehaviour
{
    public GameObject buildModelsHolder;

    public LayerMask buildLayer;
    private GameObject currentPreviewGameObject;
    private Preview currentPreviewScript;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPreviewGameObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, buildLayer))
            {
                currentPreviewGameObject.transform.position = hit.point;
            }
        }

        //Build Preview
        if (Input.GetMouseButtonDown(1) && currentPreviewGameObject != null)
        {
            if (currentPreviewScript.isBuildable || currentPreviewGameObject.CompareTag("Enemy"))
            {
                Destroy(currentPreviewGameObject.GetComponent<Preview>());
                currentPreviewGameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                currentPreviewGameObject = null;
            }
        }

        //if mouse is scrolled
        if (Input.mouseScrollDelta != new Vector2(0, 0))
        {
            RotateCurrentPreview();
        }
    }

    public void RotateCurrentPreview()
    {
        if (currentPreviewGameObject != null)
        {
            currentPreviewGameObject.transform.Rotate(0, 90, 0);
        }
    }

    public void StartBuildMode(GameObject gO)
    {
        if (currentPreviewGameObject == null)
        {
            currentPreviewGameObject = Instantiate(gO, buildModelsHolder.transform);

            //Rigidbody kinem, is imported for check triggers in preview.
            Rigidbody rb;
            if (currentPreviewGameObject.GetComponent<Rigidbody>() != null)
            {
                rb = currentPreviewGameObject.GetComponent<Rigidbody>();
            }
            else
            {
                rb = currentPreviewGameObject.AddComponent<Rigidbody>();
            }

            rb.isKinematic = true;

            currentPreviewScript = currentPreviewGameObject.AddComponent<Preview>();
        }
    }
}