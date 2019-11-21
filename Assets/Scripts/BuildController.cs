using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildController : MonoBehaviourPun
{
    public GameObject buildModelsHolder;

    public GameObject standardFloorPrefab;
    
    public LayerMask buildLayer;
    private GameObject currentPreviewGameObject;
    private Preview currentPreviewScript;
    public bool deleteAfterSec = false;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.NickName == "mobile")
        {
            if (currentPreviewGameObject != null)
            {
                
                Camera cam = GameObject.FindWithTag("MobilePlayer").GetComponentInChildren<Camera>();
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildLayer))
                {
                    currentPreviewGameObject.transform.position = hit.point;
                }
            }

            //Build Preview
            if (Input.GetMouseButtonDown(1) && currentPreviewGameObject != null)
            {
                if (currentPreviewScript.IsBuildable || currentPreviewGameObject.CompareTag("Enemy"))
                {
                    photonView.RPC("InstantiateWithPhoton", RpcTarget.All,currentPreviewGameObject.transform.position);

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
    }

    public void RotateCurrentPreview()
    {
        if (currentPreviewGameObject != null)
        {
            currentPreviewGameObject.transform.Rotate(0, 90, 0);
        }
    }

    public void StartBuildMode()
    {
        if (currentPreviewGameObject == null)
        {
            
            currentPreviewGameObject = Instantiate(standardFloorPrefab, buildModelsHolder.transform);

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

    [PunRPC]
    void InstantiateWithPhoton(Vector3 pos)
    {
        Instantiate(standardFloorPrefab, pos,
            Quaternion.identity);
    }
}