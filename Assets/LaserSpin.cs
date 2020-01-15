using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpin : MonoBehaviour
{
    private int spin;
    // Update is called once per frame
    void Update()
    {
        spin++;
        spin *= 2;
        
        transform.Rotate(new Vector3(0,spin,0));
    }
}
