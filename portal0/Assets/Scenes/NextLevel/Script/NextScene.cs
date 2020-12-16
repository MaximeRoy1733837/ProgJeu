using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{
    public AudioClip nextSceneSound;
    public GameObject soundTransition;

    //private AudioSource myAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PortalGameManager>().LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex + 1);
            Instantiate(soundTransition, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}