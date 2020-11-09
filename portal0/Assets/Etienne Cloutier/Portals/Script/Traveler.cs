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
                    //save origine porsition rotation velocity
                    Vector3 originPos = transform.position;
                    Quaternion originRot = transform.rotation;
                    Vector3 origineVelocity = body.velocity;

                    //change rotation
                    transform.rotation = portalManager.GetOffsetRotation(originRot,originPos);
                    //change position
                    transform.position = portalManager.GetOffsetPosition(originPos);
                    //change velocity
                    body.velocity = portalManager.GetOffsetRotation(Quaternion.Euler(origineVelocity), originPos)*origineVelocity;
                    GetComponentInChildren<PlayerCamera>().setCameraRotation();
                    //cam.MoveRotation(Quaternion.Euler(new Vector3(portalManager.GetOffsetRotation(originRot, originPos).x, portalManager.GetOffsetRotation(originRot, originPos).y, portalManager.GetOffsetRotation(originRot, originPos).z)));


                    portalManager.Traveling();
                }
            }
        }
    }
}
