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
        /*otherPortal.rotation = new Quaternion();
        otherPortal.position = new Vector3(0, 0, 0);*/
    }
    void Start()
    {
        playerCamera = FindObjectOfType<CharacterController>().transform;

    }
    void Update()
    {
       // transform.position = new Vector3(0, 0, 0);
        //portal cam position
        Vector3 playerOffsetFromPortal = playerCamera.position - portal.position;
        transform.position = otherPortal.position - playerOffsetFromPortal;
        //portal cam rotation
        float angularDifferenceBetweenPortalRotation = Quaternion.Angle(otherPortal.rotation, portal.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotation, Vector3.up);
        Vector3 newCameraDirection = (portalRotationalDifference * playerCamera.forward);
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up); 
        transform.rotation *= Quaternion.Euler(0, -180, 0);
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
