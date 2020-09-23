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

    }

    // Update is called once per frame
    void Update()
    {
        portalCooldownLeft -= Time.deltaTime;
        if(portalCooldownLeft<=0)
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                CreatePortal(portalBlue,new Color(41, 2, 181,255));
                portalCooldownLeft = portalCooldown;
            }
            else if (Input.GetAxis("Fire2") != 0)
            {
                CreatePortal(portalOrange,new Color(242, 120, 19,0));
                portalCooldownLeft = portalCooldown;
            }
        }
    }

    void CreatePortal(GameObject portal,Color aColor)
    {
        if(portal !=null)
        {
            Destroy(portal);
        }
        PortalCamera aCamera;

        portal = Instantiate(PortalPrefab, transform.position, transform.rotation);
        aCamera = portal.GetComponentInChildren<PortalCamera>();
        SetMaterial(portal,aCamera,aColor);
    }

    void SetMaterial(GameObject portal, PortalCamera aCamera,Color aColor)
    {
        portal.GetComponentInChildren<PortalCenter>().GetComponent<Renderer>().material = aCamera.GetMaterial();
        portal.GetComponentInChildren<PortalContour>().GetComponent<Renderer>().material.color = aColor;
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
           // portalBlue.GetComponentInChildren<PortalCamera>().ResetTexture();
           portalBlue.GetComponentInChildren<PortalCamera>().UpdateOtherPortal(portalOrange.transform);
           portalOrange.GetComponentInChildren<PortalCamera>().UpdateOtherPortal(portalBlue.transform);
            /* PortalCamera aCamera = portalBlue.GetComponentInChildren<PortalCamera>();
             SetMaterial(portalBlue, aCamera);
             aCamera= portalOrange.GetComponentInChildren<PortalCamera>();
             SetMaterial(portalOrange, aCamera);*/
        }
       
    }
}
