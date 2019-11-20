using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserController : MonoBehaviour
{

    public GameObject laser;
    
    public SteamVR_Input_Sources laserInput;

    public SteamVR_Action_Boolean laserAction;

    public SteamVR_Action_Boolean grabAction;
    
    public SteamVR_Action_Vector2 trackpadAction;

    public GameObject grabPoint;

    public float dragSpeed;


    private GameObject hitGameObject = null;
    
    private bool laserActive = false;

    private RaycastHit hit;

    private Vector2 trackpad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trackpad = trackpadAction.GetAxis(laserInput);
        print(trackpad);
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
            if (Physics.Raycast(transform.position, raydir, out hit, Mathf.Infinity))
            {



                if (grabAction.GetStateDown(laserInput))
                {
                    Debug.Log("Irgendwas");
                    
                    if (hit.collider.gameObject.CompareTag("Metal"))
                    {
                        hitGameObject = hit.collider.gameObject;
                        hitGameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hitGameObject.GetComponent<Collider>().isTrigger = true;

                        grabPoint.transform.position = hitGameObject.transform.position;
                        
                    }
                }
            }
        }
        
        if(grabAction.GetStateUp(laserInput) && hitGameObject != null)
        {
            hitGameObject.GetComponent<Rigidbody>().isKinematic = false;
            hitGameObject.GetComponent<Collider>().isTrigger = false;
            hitGameObject.transform.parent = null;
            hitGameObject = null;
        }
        
        if(hitGameObject != null)
        {
            grabPoint.transform.Translate(dragSpeed * Time.deltaTime * trackpad.y * (grabPoint.transform.position-transform.position).normalized, Space.World);
            hitGameObject.transform.position = grabPoint.transform.position;
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
