using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LavaController : MonoBehaviour
{
    public Text lavaTimer;
    public Text lavaText;
    public float timer = 20;
    private Animation animation;

    private void Start()
    {
        animation = GetComponent<Animation>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            lavaTimer.text = timer.ToString();
        }
        else
        {
            animation.Play();
            Destroy(lavaText);
            Destroy(lavaTimer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}