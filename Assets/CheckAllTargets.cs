using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CheckAllTargets : MonoBehaviour
{
    private CheckGreenTarget greenTarget;
    private CheckRedTarget redTarget;
    private CheckYellowTarget yellowTarget;
    private CheckPinkTarget pinkTarget;

    private void Start()
    {
       
   
    }
    void Update()
    {
        if (greenTarget.GetGreen() && yellowTarget.GetYellow() && pinkTarget.GetPink() 
            && redTarget.GetRed())
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            PhotonNetwork.LoadLevel("Level" + PlayerPrefs.GetInt("level").ToString());
            print(PlayerPrefs.GetInt("level"));
        }
    }



}
