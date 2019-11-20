using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkGameManager : MonoBehaviourPunCallbacks
{
    public GameObject VRPlayerPrefab;

    public GameObject mobilePlayerPrefab;

    public Transform mobilePlayerSpawn;

    public Transform vrPlayerSpawn;

    private Scene scene;
    
    
    // Start is called before the first frame update
    
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        
        GameObject player;
        
       
        if (PhotonNetwork.NickName == "VR")
        {
            player = PhotonNetwork.Instantiate(this.VRPlayerPrefab.name, vrPlayerSpawn.position, Quaternion.identity, 0);

            if (scene.name == "Level2")
            {
                player.AddComponent<FogLayer>();
            }
            
            player.transform.Find("Camera (eye)").gameObject.SetActive(true);
        }
        else if (PhotonNetwork.NickName == "mobile")
        {
            player = PhotonNetwork.Instantiate(this.mobilePlayerPrefab.name, mobilePlayerSpawn.position, mobilePlayerSpawn.rotation, 0);
            player.transform.Find("Main Camera").gameObject.SetActive(true);
        }

        

       

    }
   
}