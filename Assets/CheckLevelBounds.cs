using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckLevelBounds : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().name);
    }
}

