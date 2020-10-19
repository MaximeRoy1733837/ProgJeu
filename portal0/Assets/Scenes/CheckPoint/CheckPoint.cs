﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public Renderer renderer;
    public Material checkPointOff;
    public Material checkPointOn;

    void Start()
    {
        
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
            CheckPointOn();

            //son

            //element au meme endroit

            //setSpawnPoint(transform.position)

        }
    }
}
