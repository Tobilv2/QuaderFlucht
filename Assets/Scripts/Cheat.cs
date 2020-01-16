using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Cheat : MonoBehaviourPunCallbacks
{
    public GameObject Lava1;
    public GameObject Lava2;
    public GameObject Lava3;
    
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Metal"))
      {
       
            photonView.RPC("RemoveLava",RpcTarget.All);
            
      }
   }

   [PunRPC]
   void RemoveLava()
   {
       Lava1.SetActive(false);
       Lava2.SetActive(false);
       Lava3.SetActive(false);
   }
}
