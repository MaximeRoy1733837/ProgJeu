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

    private PortalManager portalManager;
    void Awake()
    {
        myCamera = GetComponent<Camera>();
        ResetTexture();
    }
    void Start()
    {
        
        playerCamera = FindObjectOfType<PlayerCamera>().transform;

        otherPortal = transform;
        otherPortal.position = transform.position * 2;

    }
    void Update()
    {
        //portal cam position
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;
        //portal cam rotation
        float angularDifferenceBetweenPortalRotation = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotation, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }

    public void ResetTexture()
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
    }

}
