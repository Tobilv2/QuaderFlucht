using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public new Animation bridgeAnim;
    private bool BridgeIsExtended;

    private void Start()
    {

        BridgeIsExtended = false;
        
    }

    public void ExtendBridge()
    {
        if (!BridgeIsExtended)
        {
            bridgeAnim.Play();
            BridgeIsExtended = true;
        }
    } 
    
    public void RetractBridge()
    {
        if (BridgeIsExtended)
        {
            GetComponent<Animation>().Play("BridgeRetract");
            BridgeIsExtended = false;
        }
    }
}