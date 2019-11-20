using Photon.Pun;
using UnityEngine;


public class ReloadLevel : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        other.CompareTag("VRPlayer");
        PhotonNetwork.LoadLevel("Level3");
    }
}

