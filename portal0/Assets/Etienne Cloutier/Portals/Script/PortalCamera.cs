using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Video;

public class PortalCamera : MonoBehaviour
{
    private Camera myCamera;

    private Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    private Material cameraMaterial;
    private RenderTexture renderTexture;
    void Awake()
    {
        myCamera = GetComponent<Camera>();
        ResetTexture();
    }
    void Start()
    {
        playerCamera = portal.GetComponentInParent<SelfPortal>().getPortalManager().GetComponentInChildren<PlayerCamera>().transform;
        //playerCamera = FindObjectOfType<CharacterController>().transform;
    }
    void Update()
    {   
        //portal cam position
        Vector3 playerOffsetFromPortal = (playerCamera.position - portal.position);
        //in prtal frame Px Py Pz (C.C.)
        float px = Vector3.Dot(playerOffsetFromPortal,portal.right);
        float py = Vector3.Dot(playerOffsetFromPortal,portal.up);
        float pz= Vector3.Dot(playerOffsetFromPortal,portal.forward);

        Vector3 playerOffsetFromOtherPortal = otherPortal.up*py -otherPortal.right*px - otherPortal.forward*pz;
        transform.position = otherPortal.position + playerOffsetFromOtherPortal;


        //portal cam rotation
        Quaternion reverse = new Quaternion(0,1,0,0);
        transform.rotation = otherPortal.rotation * reverse*Quaternion.Inverse(portal.rotation)*playerCamera.rotation   ;
    }

    public void ResetTexture()
    {
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        myCamera.targetTexture = renderTexture;
        
        cameraMaterial = new Material(Shader.Find("Unlit/PortalShader"));
        cameraMaterial.SetTexture("_MainTex", renderTexture);

        cameraMaterial.mainTexture = renderTexture;
    }

    public void UpdateOtherPortal(Transform aOtherPortal)
    {
        otherPortal = aOtherPortal;
    }

    public Material GetMaterial()
    {
        return cameraMaterial;
    }

  


}
