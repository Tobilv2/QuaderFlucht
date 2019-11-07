using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserController : MonoBehaviour
{

    public GameObject laser;
    
    public SteamVR_Input_Sources laserInput;

    public SteamVR_Action_Boolean laserAction;

    public GameObject testPrefab;

    public GameObject grabPoint;

    

    private bool laserActive = false;
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
        

        if (laserActive)
        {
            Vector3 raydir = laser.transform.position - transform.position;
            if (Physics.Raycast(transform.position, raydir, out var hit, Mathf.Infinity))
            {
                Instantiate(testPrefab, hit.point, Quaternion.identity);
                
            }
            
        }
    }

    private void ShowLaser()
    {
        laser.SetActive(true);
        laserActive = true;
    }

    private void HideLaser()
    {
        laser.SetActive(false);
        laserActive = false;
    }
}
