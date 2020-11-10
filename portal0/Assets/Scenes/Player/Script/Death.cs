﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;

public class Death : MonoBehaviour
{
    private float FadeToBlackTime = 1.0f;

    public Animator TransitionNoir;
    public GameObject player;
    private UnityEngine.UI.Image FadeToBlack;
    private Color FadeToBlackColor;
    public AudioSource audio;
    public AudioClip deathSound;
    public int life = 3;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        this.FadeToBlack = GameObject.Find("FadeToBlack").GetComponent<UnityEngine.UI.Image>();
        this.FadeToBlackColor = GameObject.Find("FadeToBlack").GetComponent<UnityEngine.UI.Image>().color;

        this.FadeToBlackColor.a = 0;
        this.FadeToBlack.color = this.FadeToBlackColor;
        player = GameObject.Find("Player");

        //Vector3 layerPosition = (GameObject.Find("Your_Name_Here").transform.position);
        //print(layerPosition);
    }
    // Update is called once per frame
    private void Update()
    {

        
        Vector3 layerPosition = player.transform.position;
       // print("updateDeath");
        print(layerPosition);
        if(layerPosition.y < 0)
        {
            
            theDeath();         
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
        int Alife = life;

        if (life > 0)
        {
            ReSpawn();
            life = Alife - 1;
        }
        else if (life <= 0)
        {
            ReSpawn();
            this.FadeToBlackColor.a = 1f;
            this.FadeToBlack.color = this.FadeToBlackColor;
        }
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
        player.transform.position = respawnPoint;

        

        int cpt = 0;
       // foreach (GameObject gameObjectToMove in gameobjects)
        //{
            //gameObjectToMove.transform.position = gameobjectsPosition[cpt];
            //cpt++;
        //}
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

    
