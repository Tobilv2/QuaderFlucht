using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRModelController : MonoBehaviour
{

    public GameObject camera;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(camera.transform.position.x + offset.x, camera.transform.position.y + offset.y, camera.transform.position.z + offset.z );
    }
}
