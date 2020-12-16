using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionSound : MonoBehaviour
{
    
    void Start()
    {
        AudioSource audioSource;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        audioSource.Play();
        Destroy(gameObject,audioSource.clip.length);
    }
}
