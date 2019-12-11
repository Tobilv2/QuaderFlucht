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

    public float chaseSpeed;

    public float minDistance;


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
                    
                    if (hit.collider.gameObject.CompareTag("Metal") || hit.collider.gameObject.layer.Equals("Metal"))
                    {
                        hitGameObject = hit.collider.gameObject;
                        hitGameObject.GetComponent<Rigidbody>().useGravity = false;

                        grabPoint.transform.position = hitGameObject.transform.position;
                        
                    }
                }
            }
        }
        
        if(grabAction.GetStateUp(laserInput) && hitGameObject != null)
        {
            Rigidbody hitRigidbody = hitGameObject.GetComponent<Rigidbody>();
            hitRigidbody.useGravity = true;
            hitRigidbody.AddForce(grabPoint.transform.position-hitGameObject.transform.position,ForceMode.Impulse);
            hitGameObject = null;
        }
        
        if(hitGameObject != null)
        {
            if (((grabPoint.transform.position - transform.position).magnitude >= minDistance) || trackpad.y > 0f)
            {
                grabPoint.transform.Translate(
                    dragSpeed * Time.deltaTime * trackpad.y *
                    (grabPoint.transform.position - transform.position).normalized, Space.World);
            }

            //hitGameObject.transform.position = grabPoint.transform.position;
            hitGameObject.transform.Translate((chaseSpeed)*Time.deltaTime*(grabPoint.transform.position-hitGameObject.transform.position),Space.World);
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
