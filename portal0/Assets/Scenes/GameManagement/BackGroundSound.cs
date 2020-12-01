using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip audioClipBackGround = Resources.Load<AudioClip>("Audio/Background");
        audioSource.PlayOneShot(audioClipBackGround);

    }
}
