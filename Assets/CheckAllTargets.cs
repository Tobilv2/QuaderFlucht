using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllTargets : MonoBehaviour
{
    public Animation door;
    private CheckGreenTarget greenTarget;
    private CheckRedTarget redTarget;
    private CheckYellowTarget yellowTarget;
    private CheckPinkTarget pinkTarget;
  
    void Update()
    {
        if (this.greenTarget.green && yellowTarget.yellow && pinkTarget && redTarget)
        {
            door.Play("OpenDoor");
        }
    }



}
