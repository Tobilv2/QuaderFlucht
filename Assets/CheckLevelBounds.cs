using Photon.Pun;
using UnityEngine;


public class CheckLevelBounds : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.LoadLevel("Level3");
    }
}

