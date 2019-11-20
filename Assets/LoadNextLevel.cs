using UnityEngine;
using Photon.Pun;

public class LoadNextLevel : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.LoadLevel("Level5");
    }
}
