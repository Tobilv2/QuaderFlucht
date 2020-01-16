using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviourPunCallbacks
{
    public GameObject Credits;
    private void OnTriggerEnter(Collider other)
    {
        photonView.RPC("StartCredits",RpcTarget.All);
    }

    [PunRPC]
    void StartCredits()
    {
        Credits.SetActive(true);
    }


    public void LoadMenu()
    {
        photonView.RPC("LoadMenuPun",RpcTarget.All);
    }
    
    [PunRPC]
    void LoadMenuPun()
    {
        PhotonNetwork.LoadLevel(0);
    }
}
