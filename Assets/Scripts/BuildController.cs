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
        Debug.Log(PhotonNetwork.NickName);
        if (PhotonNetwork.NickName == "mobile")
        {
            Debug.Log("STUFE 2");
            if (currentPreviewGameObject != null)
            {
                Debug.Log("STUFE 3");
                Camera cam = GameObject.FindWithTag("MobilePlayer").GetComponentInChildren<Camera>();
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin,ray.direction*1000,Color.magenta);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildLayer))
                {
                    Debug.Log(hit.point);
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
        Instantiate(currentPrefab, currentPreviewGameObject.transform.position,
            Quaternion.identity);
    }
}