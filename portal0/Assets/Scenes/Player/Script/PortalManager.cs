using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject PortalPrefab;

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

    void Update()
    {
        /*portalCooldownLeft -= Time.deltaTime;
        if(portalCooldownLeft<=0)
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                //portalBlue = CreatePortal(portalBlue,new Color(41f / 255, 2f / 255, 181f / 255));
                portals[0] = CreatePortal(0,new Color(41f / 255, 2f / 255, 181f / 255));
                portalCooldownLeft = portalCooldown;
                ReSyncPortals();
            }
            else if (Input.GetAxis("Fire2") != 0)
            {
                //Destroy(portalOrange);
                //portalOrange = CreatePortal(portalOrange,new Color(242f / 255, 120f / 255, 19f/255));
                portals[1] = CreatePortal(1,new Color(242f / 255, 120f / 255, 19f/255));
                portalCooldownLeft = portalCooldown;
                ReSyncPortals();
            }
        }*/
    }

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
        }
    }

    void SetMaterial(GameObject portal, PortalCamera aCamera,Color aColor)
    {
        portal.GetComponentInChildren<PortalCenter>().GetComponent<Renderer>().material = aCamera.GetMaterial();
        portal.GetComponentInChildren<PortalContour>().GetComponent<Renderer>().material.color= aColor; 
    }

    void SetMaterial(GameObject portal,Color color)
    {
        Renderer portalRender = portal.GetComponentInChildren<PortalCenter>().GetComponent<Renderer>();
    }

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
        }
    }

    public void ChangePortalColor(int noPortal,Color aColor)
    {
        if(noPortal < colorPortail.Length)
        {
            colorPortail[noPortal] = aColor;
        }
    }
}
