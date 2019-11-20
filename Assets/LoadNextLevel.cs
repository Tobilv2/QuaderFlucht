using System;
using UnityEngine;
using Photon.Pun;

public class LoadNextLevel : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PlayerPrefs.SetInt("level",2);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("level",PlayerPrefs.GetInt("level")+1);
        PhotonNetwork.LoadLevel(PlayerPrefs.GetInt("level"));
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
