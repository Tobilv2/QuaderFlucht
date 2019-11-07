using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVisibility : MonoBehaviour
{

    public Light mainLight;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPreCull()
    {
        mainLight.enabled = false;
    }

    private void OnPostRender()
    {
        mainLight.enabled = true;
    }
}
