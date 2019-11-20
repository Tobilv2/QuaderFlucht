using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviourPunCallbacks
{
    private void Start()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRPlayer"))
        {

            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            PhotonNetwork.LoadLevel("Level" + PlayerPrefs.GetInt("level").ToString());
            print(PlayerPrefs.GetInt("level"));
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
