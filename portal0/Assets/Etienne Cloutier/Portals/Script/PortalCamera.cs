using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Video;

public class PortalCamera : MonoBehaviour
{
    private Camera myCamera;

    private Camera playerCamera;
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
        playerCamera = portal.GetComponentInParent<SelfPortal>().getPortalManager().GetComponentInChildren<Camera>();
    }
    void Update()
    {   
        //portal cam position
        Vector3 playerOffsetFromPortal = (playerCamera.transform.position - portal.position);
        //in prtal frame Px Py Pz (C.C.)
        float px = Vector3.Dot(playerOffsetFromPortal,portal.right);
        float py = Vector3.Dot(playerOffsetFromPortal,portal.up);
        float pz= Vector3.Dot(playerOffsetFromPortal,portal.forward);

        Vector3 playerOffsetFromOtherPortal = otherPortal.up*py -otherPortal.right*px - otherPortal.forward*pz;
        transform.position = otherPortal.position + playerOffsetFromOtherPortal;

        //portal cam rotation
        Quaternion reverse = new Quaternion(0,1,0,0);
        transform.rotation = otherPortal.rotation * reverse*Quaternion.Inverse(portal.rotation)*playerCamera.transform.rotation   ;

        //portal cam Clipping
        // myCamera.nearClipPlane = (myCamera.transform.position - otherPortal.position).magnitude+0.2f;

        Transform clipPlane = otherPortal.transform;
        int dot = System.Math.Sign(Vector3.Dot(clipPlane.forward, otherPortal.position - myCamera.transform.position));

        Vector3 camSpacePos = myCamera.worldToCameraMatrix.MultiplyPoint(clipPlane.position);
        Vector3 camSpaceNormal = myCamera.worldToCameraMatrix.MultiplyVector(clipPlane.forward) * dot;
        float camSpaceDst = -Vector3.Dot(camSpacePos, camSpaceNormal) + 0.1f;

        Vector4 clipPlaneCameraSpace = new Vector4(camSpaceNormal.x, camSpaceNormal.y, camSpaceNormal.z, camSpaceDst);

        // Update projection based on new clip plane
        // Calculate matrix with player cam so that player camera settings (fov, etc) are used
        myCamera.projectionMatrix = playerCamera.CalculateObliqueMatrix(clipPlaneCameraSpace);
 

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
