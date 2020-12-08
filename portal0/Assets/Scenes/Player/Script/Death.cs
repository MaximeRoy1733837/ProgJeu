using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private float FadeToBlackTime = 1.0f;

    public Animator TransitionNoir;
    public GameObject player;
    private UnityEngine.UI.Image FadeToBlack;
    private Color FadeToBlackColor;
    public AudioSource audio;
    public AudioClip deathSound;
    public static int life = 3;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        this.FadeToBlack = GameObject.Find("FadeToBlack").GetComponent<UnityEngine.UI.Image>();
        this.FadeToBlackColor = GameObject.Find("FadeToBlack").GetComponent<UnityEngine.UI.Image>().color;

        this.FadeToBlackColor.a = 0;
        this.FadeToBlack.color = this.FadeToBlackColor;
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    private void Update()
    {
        Vector3 layerPosition = player.transform.position;
        if(layerPosition.y < 0)
        {
            ReSpawn();         
        }
    }

    public void theDeath()
    {

        this.FadeToBlackColor.a = 1f;
        this.FadeToBlack.color = this.FadeToBlackColor;

        //print(FadeToBlackTime);
        while (FadeToBlackTime > 0)
        {
            this.FadeToBlackColor.a = FadeToBlackTime;
            this.FadeToBlack.color = this.FadeToBlackColor;
            FadeToBlackTime -= Time.deltaTime;
        }
        FadeToBlackTime = 1.0f;
    }



    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f);
    }

    public List<GameObject> gameobjects = new List<GameObject>();
    public List<Vector3> gameobjectsPosition = new List<Vector3>();
    Vector3 respawnPoint;



    public void ReSpawn()
    {
        audio.PlayOneShot(deathSound,1f);
        life -= 1;

        if (life > 0)
        {
            player.transform.position = respawnPoint;
            
        }
        else if (life <= 0)
        {
            life = 3;
            GameObject.FindObjectOfType<PortalGameManager>().LoadSceneByIndex(0);
            GameObject.FindObjectOfType<PortalGameManager>().BackToMenu();
        }
    }
    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
    public void SetObjetPosition(GameObject gameObjectToMove, Vector3 newPosition)
    {
        gameobjects.Add(gameObjectToMove);
        gameobjectsPosition.Add(newPosition);
    }
    public void viderList()
    {
        gameobjects.Clear();
        gameobjectsPosition.Clear();
    }
}

    

