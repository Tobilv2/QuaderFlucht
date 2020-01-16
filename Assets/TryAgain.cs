using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TryAgain : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        audioSource.clip = audioClip;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (PhotonNetwork.NickName == "VR" && other.CompareTag("VRPlayer"))
        {
            audioSource.Play();
        }
    }
}
