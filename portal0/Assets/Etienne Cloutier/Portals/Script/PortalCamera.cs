using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Video;

public class PortalCamera : MonoBehaviour
{
    private Camera myCamera;

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    private Material cameraMaterial;
    private RenderTexture renderTexture;
    void Awake()
    {
        myCamera = GetComponent<Camera>();
        //ResetTexture();
        /*otherPortal.rotation = new Quaternion();
        otherPortal.position = new Vector3(0, 0, 0);*/
    }
    void Start()
    {
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
        float angularDifferenceBetweenPortalRotation = Quaternion.Angle(otherPortal.rotation, portal.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotation, Vector3.up);
        Vector3 newCameraDirection = (portalRotationalDifference * (new Vector3(-playerCamera.forward.x,playerCamera.forward.y,-playerCamera.forward.z)));
        //transform.rotation = portalRotationalDifference * playerCamera.rotation;
        //transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        Quaternion reverse = new Quaternion(0,1,0,0);
        //transform.rotation = (playerCamera.rotation * Quaternion.Inverse(portal.rotation)*reverse)*otherPortal.rotation ;
        transform.rotation = otherPortal.rotation * reverse*Quaternion.Inverse(portal.rotation)*playerCamera.rotation   ;
    }

   /* public void ResetTexture()
    {
        cameraMaterial = new Material(Shader.Find("Standard"));

        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);

        myCamera.targetTexture = renderTexture;
        cameraMaterial.mainTexture = renderTexture;
    }

    public void UpdateOtherPortal(Transform aOtherPortal)
    {
        otherPortal = aOtherPortal;
    }

    public Material GetMaterial()
    {
        return cameraMaterial;
    }*/

}
