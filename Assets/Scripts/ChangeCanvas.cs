using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    public Canvas playerCanvas;
    public Canvas startScreen;
    // Start is called before the first frame update
    void Start()
    {
        playerCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            startScreen.enabled = false;
            playerCanvas.enabled = true;
        }
    }
}
