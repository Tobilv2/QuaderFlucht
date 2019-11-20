using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorVisibility : MonoBehaviour
{

    public GameObject floor;
    public Text unvisibleTimer;
    public Text floorText;
    public float timer = 20;
    void Start()
    {
        floor = gameObject.GetComponentInChildren<MeshRenderer>().gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            unvisibleTimer.text = timer.ToString();
        }
        else
        {
            foreach (var meshRenderer in GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.enabled = false;
            }

            Destroy(floorText);
            Destroy(unvisibleTimer);
        }

        
    }
    
}
