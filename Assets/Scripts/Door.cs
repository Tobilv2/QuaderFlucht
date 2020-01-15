using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    private new Animation animation;
    private bool DoorIsOpen;

    private void Start()
    {
        audioSource.clip = audioClip;
        DoorIsOpen = true;
        CloseDoor();
    }

    public void OpenDoor()
    {
        if (!DoorIsOpen)
        {
            GetComponent<Animation>().Play("OpenDoor");
            audioSource.Play();
            DoorIsOpen = true;
        }
    } 
    
    public void CloseDoor()
    {
        if (DoorIsOpen)
        {
            GetComponent<Animation>().Play("CloseDoor");
            audioSource.Play();
            DoorIsOpen = false;
        }
    }
}