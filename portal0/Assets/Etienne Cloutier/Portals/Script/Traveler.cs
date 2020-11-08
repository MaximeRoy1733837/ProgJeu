using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Traveler : MonoBehaviour
{
    private Rigidbody body;

    private float TPCooldown = 0f;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        TPCooldown -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Portal" && TPCooldown <= 0)
        {
            TPCooldown = 0.05f;
            SelfPortal portal = collider.GetComponentInParent<SelfPortal>();
            if (portal != null)
            {
                PortalManager portalManager = portal.getPortalManager();
                if (portalManager != null)
                {
                    //PlayerCamera playerCamera = gameObject.GetComponentInChildren<PlayerCamera>();

                    /*if (playerCamera != null)
                    {
                        playerCamera.RestRotation();
                    }*/

                    //create new obj
                    Vector3 originPos = transform.position;//new Vector3(transform.position.x,transform.position.y,transform.position.z);
                    Quaternion originRot = transform.rotation;

                    //change rotation
                    /***********BUG**********
                    la rotation est changer par player camera 
                    il faut changer la rotation du joueur sans quelle sois re changer par player camera
                    il faut modifier les valeurs horizontale et verticale de player camera
                    Étienne Cloutier 02 Novembre 2020
                    ************BUG END*********/

                    //transform.rotation = portalManager.GetOffsetRotation(originRot,originPos);
                    //change position
                    transform.position = portalManager.GetOffsetPosition(originPos);
                    transform.rotation = portalManager.GetOffsetRotation(originRot, originPos);
                    GetComponentInChildren<PlayerCamera>().setCameraRotation();
                    //cam.MoveRotation(Quaternion.Euler(new Vector3(portalManager.GetOffsetRotation(originRot, originPos).x, portalManager.GetOffsetRotation(originRot, originPos).y, portalManager.GetOffsetRotation(originRot, originPos).z)));


                    /*if (playerCamera != null)
                    {
                        playerCamera.RestRotation();
                    }*/

                }
            }
        }
    }
}
