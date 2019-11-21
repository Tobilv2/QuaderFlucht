using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckLevelBounds : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        if (PhotonNetwork.NickName == "VR")
        {
            PhotonNetwork.DestroyAll();
            photonView.RPC("ReloadScenesForAllPlayers",RpcTarget.All);
        }
    }

    [PunRPC]
    void ReloadScenesForAllPlayers()
    {
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().name);
    }
    
}

