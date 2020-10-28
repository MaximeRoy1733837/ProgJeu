using System.Collections;
using System.Collections.Generic;
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
                    PlayerCamera playerCamera = gameObject.GetComponentInChildren<PlayerCamera>();
                    playerCamera.RestRotation();

                    //create new obj
                    Vector3 originPos = transform.position;//new Vector3(transform.position.x,transform.position.y,transform.position.z);
                    Quaternion originRot = transform.rotation;

                    //change rotation
                    transform.rotation = portalManager.GetOffsetRotation(originRot,originPos);
                    //change position
                    transform.position = portalManager.GetOffsetPosition(originPos);


                    playerCamera.RestRotation();

                }
            }
        }
    }
}
