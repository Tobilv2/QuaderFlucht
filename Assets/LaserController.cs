using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserController : MonoBehaviour
{

    public GameObject laser;
    
    public SteamVR_Input_Sources laserInput;

    public SteamVR_Action_Boolean laserAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (laserAction.GetStateDown(laserInput))
        {
            ShowLaser();
        }
        else if (laserAction.GetStateUp(laserInput))
        {
            HideLaser();
        }
    }

    private void ShowLaser()
    {
        laser.SetActive(true);
    }

    private void HideLaser()
    {
        laser.SetActive(false);
    }
}
