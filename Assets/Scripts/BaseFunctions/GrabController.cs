using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public float radius = 1;
    public LayerMask interactable;
    GameObject grabedGameObject = null;
    private bool grabTrigger
    {
        get { return grabTrigger; }
        set
        {
            Grab();
        }
    }

    private void Update()
    {
        if (VRController.grabTriggert != grabTrigger)
        {
            grabTrigger = VRController.grabTriggert;
        }
    }

    public void Grab()
    {
        if (grabedGameObject == null)
        {
            float minDist = 0;
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, interactable);
            foreach (var collider in colliders)
            {
                float dist = Vector3.Distance(collider.transform.position, transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    grabedGameObject = collider.gameObject;
                }
            }
            if (grabedGameObject.GetComponent<Rigidbody>() != null)
            {
                grabedGameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            grabedGameObject.transform.parent = transform;
        }
        else
        {
            if (grabedGameObject.GetComponent<Rigidbody>() != null)
            {
                grabedGameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            grabedGameObject.transform.parent = null;
            grabedGameObject = null;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}