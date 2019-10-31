using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class NetworkGameManager : MonoBehaviourPunCallbacks
{
    public GameObject VRPlayerPrefab;

    public GameObject mobilePlayerPrefab;

    public Transform mobilePlayerSpawn;

    public Transform vrPlayerSpawn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player;
        if (PhotonNetwork.NickName == "VR")
        {
            player = PhotonNetwork.Instantiate(this.VRPlayerPrefab.name, vrPlayerSpawn.position, Quaternion.identity, 0);
            player.transform.Find("Camera (eye)").gameObject.SetActive(true);
            
        }
        else if (PhotonNetwork.NickName == "mobile")
        {
            player = PhotonNetwork.Instantiate(this.mobilePlayerPrefab.name, mobilePlayerSpawn.position, mobilePlayerSpawn.rotation, 0);
            player.transform.Find("Main Camera").gameObject.SetActive(true);
        }
        
    }
}
