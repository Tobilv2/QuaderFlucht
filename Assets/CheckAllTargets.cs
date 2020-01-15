using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CheckAllTargets : MonoBehaviour
{
    public Animation door;
    public CheckGreenTarget greenTarget;
    public CheckRedTarget redTarget;
    public CheckYellowTarget yellowTarget;
    public CheckPinkTarget pinkTarget;
    public Door doorObject;

    private void Start()
    {
       
   
    }
    void Update()
    {
        if (greenTarget.GetGreen() && yellowTarget.GetYellow() && pinkTarget.GetPink() 
            && redTarget.GetRed())
        {
            doorObject.OpenDoor();
        }
    }



}
