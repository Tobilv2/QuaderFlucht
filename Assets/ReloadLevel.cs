using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    PhotonNetwork.LoadLevel(PlayerPrefs.GetInt("level"));
  }
}
