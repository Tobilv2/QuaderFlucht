using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private new Animation animation;
    private bool BridgeIsExtended;

    private void Start()
    {

        BridgeIsExtended = false;
        
    }

    public void ExtendBridge()
    {
        if (!BridgeIsExtended)
        {
            GetComponent<Animation>().Play("BridgeAnimationExtend");
            BridgeIsExtended = true;
        }
    } 
    
    public void RetractBridge()
    {
        if (BridgeIsExtended)
        {
            GetComponent<Animation>().Play("BridgeAnimationRetract");
            BridgeIsExtended = false;
        }
    }
}