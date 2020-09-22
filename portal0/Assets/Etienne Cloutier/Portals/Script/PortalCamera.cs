using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    private Camera camera;

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    private Material cameraMaterial;

    void Start()
    {
        cameraMaterial = new Material(Shader.Find("Standard"));
        camera = GetComponent<Camera>();

        playerCamera = FindObjectOfType<PlayerCamera>().transform;
        otherPortal = transform;
        otherPortal.position = transform.position * 2;

        camera.targetTexture = new RenderTexture(Screen.width,Screen.height,24);
        cameraMaterial.mainTexture = camera.targetTexture;
        
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

    public void UpdateOtherPortal(Transform aOtherPortal)
    {
        otherPortal = aOtherPortal;
    }
}
