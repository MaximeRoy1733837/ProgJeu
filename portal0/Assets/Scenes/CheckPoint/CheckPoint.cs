using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CheckPoint : MonoBehaviour
{
    //public Death death;

    public Renderer renderer;
    public Material checkPointOff;
    public Material checkPointOn;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    public void CheckPointOn()
    {
        CheckPoint[] checkPoints = FindObjectsOfType<CheckPoint>();
        foreach(CheckPoint checkPoint in checkPoints)
        {
            checkPoint.CheckPointOff();
        }
        renderer.material = checkPointOn;
    }
    public void CheckPointOff()
    {
        renderer.material = checkPointOff;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            //couleur
            CheckPointOn();

            //son
            audioSource.Play();

            //set element au meme endroit
            GameObject[] gameobjets = FindObjectsOfType<GameObject>();
            foreach (GameObject gameObjectToMove in gameobjets)
            {
                //death.SetObjetPosition(gameObjectToMove, gameObjectToMove.transform.position);
            }

            //setSpawnPoint
            //death.SetSpawnPoint(transform.position);
        }
    }
}

//Dans le script Death:

//public void SetSpawnPoint(Vector3 newPosition)
//{
//    respawnPoint = newPosition;
//}

//public void SetObjetPosition(GameObject gameObjectToMove, Vector3 newPosition)
//{
//    gameObjectToMove.transform.position = newPosition;
//}
