using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private int indexScene;
    public AudioClip nextSceneSound;
    public GameObject soundTransition;
    
    private AudioSource myAudio;
    private void OnTriggerEnter(Collider other)
    {
        
        myAudio.PlayOneShot(nextSceneSound);
        
        if (other.CompareTag("Player"))
        {
            try
            {
                indexScene = SceneManager.GetActiveScene().buildIndex + 1;
                Instantiate(soundTransition, gameObject.transform.position, gameObject.transform.rotation);
                SceneManager.LoadScene(indexScene);
                
                //SceneManager.LoadScene(indexScene);
            }
            catch { }
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
