using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public float radius = 1;
    public LayerMask interactable;
    GameObject grabedGameObject = null;

    public void Grab()
    {
        if (grabedGameObject == null)
        {
            float minDist = Mathf.Infinity;
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
                grabedGameObject.GetComponent<Collider>().isTrigger = true;
            }
            grabedGameObject.transform.parent = transform;
        }
        
    }

    public void letGo()
    {
        if (grabedGameObject != null && grabedGameObject.GetComponent<Rigidbody>() != null)
        {
            grabedGameObject.GetComponent<Rigidbody>().isKinematic = false;
            grabedGameObject.GetComponent<Collider>().isTrigger = false;
            
        }
        grabedGameObject.transform.parent = null;
        grabedGameObject = null;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}