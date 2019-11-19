using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FogLayer : MonoBehaviour
{

    public bool doWeHaveFogInScene = true;
    private Scene scene;

    private void Awake()
    {
        if (scene.name == "Level2")
        {
            doWeHaveFogInScene = true;
        }
    }

    private void Start()
    {
        if (scene.name == "Level2")
        {
            doWeHaveFogInScene = true;
        }
    }

    private void Update()
    {
        if (scene.name == "Level2")
        {
            doWeHaveFogInScene = true;
        }
        
        if (doWeHaveFogInScene)
        {
            RenderSettings.fog = true;
        }
        else
        {
            RenderSettings.fog = false;
        }
    }
    
}