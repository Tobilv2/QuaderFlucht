using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildController : MonoBehaviourPunCallbacks
{
    public GameObject buildModelsHolder;

    public LayerMask buildLayer;
    private GameObject currentPreviewGameObject;
    private Preview currentPreviewScript;
    public bool deleteAfterSec = false;
    private GameObject currentPrefab;

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
                if (currentPreviewScript.IsBuildable || currentPreviewGameObject.CompareTag("Enemy"))
                {
                    photonView.RPC("InstantiateWithPhoton", RpcTarget.All);

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

    public void StartBuildMode(GameObject gO)
    {
        if (currentPreviewGameObject == null)
        {
            currentPrefab = gO;
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

    [PunRPC]
    void InstantiateWithPhoton()
    {
        GameObject gO = Instantiate(currentPrefab, currentPreviewGameObject.transform.position,
            Quaternion.identity);
        if (deleteAfterSec)
        {
            Destroy(gO, 6);
        }
    }
}