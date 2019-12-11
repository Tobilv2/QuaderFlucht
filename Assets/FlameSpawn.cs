using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FlameSpawn : MonoBehaviourPun
{
    public GameObject flamePrefab;

    private void Update()
    {
        if (PhotonNetwork.NickName == "mobile")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Camera cam = GameObject.FindWithTag("MobilePlayer").GetComponentInChildren<Camera>();
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    photonView.RPC("InstantiateWithPhoton", RpcTarget.All, hit.point);
                }
            }
        }
    }

    [PunRPC]
    void InstantiateWithPhoton(Vector3 pos)
    {
        GameObject gO = Instantiate(flamePrefab, pos,
            Quaternion.identity);
        Destroy(gO, 0.5f);
    }
}