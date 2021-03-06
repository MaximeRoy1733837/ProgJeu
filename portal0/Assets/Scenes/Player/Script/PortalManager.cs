﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalManager : MonoBehaviour
{
    public GameObject PortalPrefab;
    public AudioClip teleportSound;

    private GameObject[] portals =new GameObject[2];
    private Color[] colorPortail = new Color[2];

    // Start is called before the first frame update
    void Start()
    {
        portals[0] = null;
        portals[1] = null;
        colorPortail[0] = new Color(41f / 255, 2f / 255, 181f / 255);
        colorPortail[1] = new Color(242f / 255, 120f / 255, 19f / 255);
    }

    #region portals gestion
    public void CreatePortal(int noPortal,Transform aTransform)
    {
        GameObject portal = null;
        if(noPortal<portals.Length)
        {
            portal = portals[noPortal];
       
            if(portal !=null)
            {
                Destroy(portal,0.01f);
            }
            PortalCamera aCamera;

            portal = Instantiate(PortalPrefab, aTransform.position, aTransform.rotation);
            aCamera = portal.GetComponentInChildren<PortalCamera>();
            SetMaterial(portal,aCamera,colorPortail[noPortal]);
            portals[noPortal] = portal;
            ReSyncPortals();
            portal.GetComponentInChildren<SelfPortal>().SetPortalManager(this);
        }
    }
    //sync the idle sound and gives the right camera
    void ReSyncPortals() 
    {
        Boolean doExist = true;
        for(int i=0;i<portals.Length;i++)
        {
            if(portals[i]!=null)
            {
                SetMaterial(portals[i], colorPortail[i]);
            }
            else
            {
                doExist = false;
            }
        }
        if(doExist && portals.Length>0)
        {
            portals[0].GetComponentInChildren<PortalCamera>().UpdateOtherPortal(portals[1].transform);
            portals[1].GetComponentInChildren<PortalCamera>().UpdateOtherPortal(portals[0].transform);
            //sync idle sound
            portals[0].GetComponentInChildren<AudioSource>().Stop();
            portals[1].GetComponentInChildren<AudioSource>().Stop();
            portals[0].GetComponentInChildren<AudioSource>().Play();
            portals[1].GetComponentInChildren<AudioSource>().Play();
        }
    }
    //find wich portal is the closest and return its index
    private int FindPortals(Vector3 position)
    {
        float maxDistance = -1;
        int index = -1;

        for (int i = 0; i < portals.Length; i++)
        {
            if (portals[i] != null)
            {
                float newDistance = Vector3.Distance(portals[i].transform.position, position);
                if (newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                    index = i;
                }
            }
        }
        if (index != -1)
        {
            index = Mathf.Abs(index - 1);
        }
        return index;
    }
    #endregion

    #region PortalVisual
    /*check if both setmaterial used Etienne Cloutier 08 november*/
    void SetMaterial(GameObject portal, PortalCamera aCamera, Color aColor)
    {
        portal.GetComponentInChildren<PortalCenter>().GetComponent<Renderer>().material = aCamera.GetMaterial();
        portal.GetComponentInChildren<PortalContour>().GetComponent<Renderer>().material.color = aColor;
    }
    void SetMaterial(GameObject portal, Color color)
    {
        Renderer portalRender = portal.GetComponentInChildren<PortalCenter>().GetComponent<Renderer>();
    }
    public void ChangePortalColor(int noPortal, Color aColor)
    {
        if (noPortal < colorPortail.Length)
        {
            colorPortail[noPortal] = aColor;
        }
    }
    #endregion

    #region Offset calculation
    private Vector3 ChangePositionOffset(Vector3 position,Transform portal,Transform otherPortal)
    {
        Vector3 playerOffsetFromPortal = ( position - portal.position);
        //in prtal frame Px Py Pz (C.C.)
        float px = Vector3.Dot(playerOffsetFromPortal, -portal.right);
        float py = Vector3.Dot(playerOffsetFromPortal, -portal.up);
        float pz = Vector3.Dot(playerOffsetFromPortal, portal.forward);

        Vector3 itemOffsetFromOtherPortal = otherPortal.up * -py + otherPortal.right * px + otherPortal.forward * pz;
        position = otherPortal.position + itemOffsetFromOtherPortal;
        return position;
    }
    private Quaternion ChangeRotationOffset(Quaternion rotation,Transform portal,Transform otherPortal)
    {
        Quaternion reverse = new Quaternion(0, 1, 0, 0);
        rotation = otherPortal.rotation * reverse * Quaternion.Inverse(portal.rotation) * rotation;
        return rotation;
    }
    public Vector3 GetOffsetPosition(Vector3 pos)
    {
        Vector3 position = pos;
        int index = FindPortals(pos);
        if(index!=-1)
        {
            if (portals[Math.Abs(index - 1)] != null && portals[index]!=null)
            {
                Transform portal = portals[index].transform;
                Transform otherPortal = portals[Math.Abs(index - 1)].transform;
                position = ChangePositionOffset(position, portal, otherPortal);
            }
        }
        return position;
    }  
    public Quaternion GetOffsetRotation(Quaternion rot,Vector3 pos)
    {
        Quaternion rotation = rot;
        int index = FindPortals(pos);
        if (index != -1)
        {
            if (portals[Math.Abs(index - 1)] != null && portals[index] != null)
            {
                Transform portal = portals[index].transform;
                Transform otherPortal = portals[Math.Abs(index - 1)].transform;
                rotation =  ChangeRotationOffset(rotation, portal, otherPortal);
            }
        }
        return rotation;
    }    
    //check if velocity used 
    //Etienne Cloutier 08 november
    public Vector3 GetOffsetVelocity(Vector3 item,Vector3 pos)
    {
        print("I"+item);
        Vector3 velocity = item;
        int index = FindPortals(pos);
        if (index != -1)
        {
            if (portals[Math.Abs(index - 1)] != null && portals[index] != null)
            {
                Transform portal = portals[index].transform;
                Transform otherPortal = portals[Math.Abs(index - 1)].transform;

                Quaternion q= Quaternion.FromToRotation(portal.position, otherPortal.position);
                print("Q " + q.eulerAngles);
                Vector3 vector3 = q * velocity;
                velocity = vector3;
            }
        }
        print("v"+velocity);
        return velocity;
    }
    #endregion  
    
    #region others
    //function caled when traveler goes into a portal
    public void Traveling()
    {
        foreach (GameObject portal in portals)
        {
            if (portal != null)
            {
                portal.GetComponentInChildren<AudioSource>().PlayOneShot(teleportSound);
            }
        }
    }

    #endregion
}
