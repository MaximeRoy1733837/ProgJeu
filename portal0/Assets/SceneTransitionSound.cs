using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionSound : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        audioSource.Play();
        Destroy(gameObject,audioSource.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
