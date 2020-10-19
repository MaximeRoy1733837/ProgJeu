using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

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

    public Transform GetTpTransform(Transform pos,Transform output)
    {
        float maxDistance =-1;
        int index = -1;

        for(int i=0;i<portals.Length;i++)
        {
            if(portals[i]!=null){
                float newDistance = Vector3.Distance(portals[i].transform.position, pos.position);
                if(newDistance>maxDistance)
                {
                    maxDistance = newDistance;
                    index = i;
                }
            }
        }
        if(index!=-1)
        {   
            if(portals[Math.Abs(index - 1)]!=null)
            {
                Transform portal = portals[Math.Abs(index - 1)].transform;
                Transform otherPortal = portals[index].transform;
                TransformTP(pos, portal, otherPortal, output);   
            }
        }
        return output;
    }

    private Transform TransformTP(Transform pos,Transform portal,Transform otherPortal,Transform output)
    {
        Vector3 playerOffsetFromPortal = (pos.position - portal.position);
        //in prtal frame Px Py Pz (C.C.)
        float px = Vector3.Dot(playerOffsetFromPortal, portal.right);
        float py = Vector3.Dot(playerOffsetFromPortal, portal.up);
        float pz = Vector3.Dot(playerOffsetFromPortal, portal.forward);

        Vector3 playerOffsetFromOtherPortal = otherPortal.up * py + otherPortal.right * px + otherPortal.forward * pz;
        output.position = otherPortal.position + playerOffsetFromOtherPortal;

        Quaternion reverse = new Quaternion(0, 1, 0, 0);
        output.rotation = otherPortal.rotation *reverse* Quaternion.Inverse(portal.rotation) * pos.rotation;
        return output;
    }
}
