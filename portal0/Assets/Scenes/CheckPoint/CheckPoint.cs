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
        //death.SetSpawnPoint(0,0,0);
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

            //vider les lists
            //death.viderList();

            //set element au meme endroit
            GameObject[] gameobjects = FindObjectsOfType<GameObject>();
            foreach (GameObject gameObjectToMove in gameobjects)
            {
                //death.SetObjetPosition(gameObjectToMove, gameObjectToMove.transform.position);
            }

            //set SpawnPoint
            //death.SetSpawnPoint(transform.position);
        }
    }
}

//Dans le script Death:

//public List<GameObject> gameobjects = new List<GameObject>();
//public List<Vector3> gameobjectsPosition = new List<Vector3>();
//Vector3 respawnPoint;

//public void ReSpawn()
//{
//    player.transform.position = respawnPoint;

//    int cpt = 0;
//    foreach (GameObject gameObjectToMove in gameobjects)
//    {
//        gameObjectToMove.transform.position = gameobjectsPosition[cpt];
//        cpt++;
//    }
//}

//public void SetSpawnPoint(Vector3 newPosition)
//{
//    respawnPoint = newPosition;
//}

//public void SetObjetPosition(GameObject gameObjectToMove, Vector3 newPosition)
//{
//    gameobjects.Add(gameObjectToMove);
//    gameobjectsPosition.Add(newPosition);
//}

//public void viderList()
//{
//    gameobjects.Clear();
//    gameobjectsPosition.Clear();
//}

