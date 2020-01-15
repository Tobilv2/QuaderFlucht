using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CheckAllTargets : MonoBehaviour
{
    public CheckGreenTarget greenTarget;
    public CheckRedTarget redTarget;
    public CheckYellowTarget yellowTarget;
    public CheckPinkTarget pinkTarget;

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
