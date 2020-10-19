using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : MonoBehaviour
{
    private float TPCooldown = 0f;

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
                    //pas de character controller pour les obj
                    CharacterController characterController= gameObject.GetComponentInParent<CharacterController>();
                    if(characterController!=null)
                    {
                        characterController.enabled = false;
                    }
                    portalManager.GetTpTransform(transform, transform);
                    if (characterController != null)
                    {
                        characterController.enabled = true;
                    }
                }
            }
        }
    }
}
