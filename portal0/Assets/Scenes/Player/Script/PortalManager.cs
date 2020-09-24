using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject PortalPrefab;
    public int portalCooldown = 1;

    private GameObject portalBlue;
    private GameObject portalOrange;

    private float portalCooldownLeft = 0; 
    // Start is called before the first frame update
    void Start()
    {
        portalBlue = null;
        portalOrange = null;
    }

    // Update is called once per frame
    void Update()
    {
        portalCooldownLeft -= Time.deltaTime;
        if(portalCooldownLeft<=0)
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                portalBlue = CreatePortal(portalBlue,new Color(41, 2, 181));
                portalCooldownLeft = portalCooldown;
                ReSyncPortals();
            }
            else if (Input.GetAxis("Fire2") != 0)
            {
                Destroy(portalOrange);
                portalOrange = CreatePortal(portalOrange,new Color(242, 120, 19));
                portalCooldownLeft = portalCooldown;
                ReSyncPortals();
            }
        }
    }

    GameObject CreatePortal(GameObject portal,Color aColor)
    {
        if(portal !=null)
        {
            Destroy(portal,0.01f);
        }
        PortalCamera aCamera;

        portal = Instantiate(PortalPrefab, transform.position, transform.rotation);
        aCamera = portal.GetComponentInChildren<PortalCamera>();
        SetMaterial(portal,aCamera,aColor);
        return portal;
    }

    void SetMaterial(GameObject portal, PortalCamera aCamera,Color aColor)
    {
        portal.GetComponentInChildren<PortalCenter>().GetComponent<Renderer>().material = aCamera.GetMaterial();
        //portal.GetComponentInChildren<PortalContour>().SetColor(aColor);
        //portal.GetComponentInChildren<PortalContour>().GetComponent<Renderer>().material.color = aColor;
    }

    void SetMaterial(GameObject portal,Color color)
    {
        portal.GetComponentInChildren<PortalCenter>().GetComponent<Renderer>().material.color = color;
    }

    void ReSyncPortals() 
    {
        Boolean doExist = true;
        if(portalBlue!=null)
        {
            //SetMaterial(portalBlue, new Color(41,2,181));
        }
        else
        {
            doExist = false;
        }

        if (portalOrange != null)
        {
            //SetMaterial(portalOrange, new Color(242, 120, 19));
        }
        else
        {
            doExist = false;
        }

        if(doExist)
        {
           portalBlue.GetComponentInChildren<PortalCamera>().UpdateOtherPortal(portalOrange.transform);
           portalOrange.GetComponentInChildren<PortalCamera>().UpdateOtherPortal(portalBlue.transform);
        }
       
    }
}
