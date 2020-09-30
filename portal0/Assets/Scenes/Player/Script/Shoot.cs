using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private PortalManager portalManager;
    private Camera cam;

    public float portalCooldown = 0.3f;
    public float range = 100f;


    private float portalCooldownLeft = 0;

    void Start()
    {
        portalManager = gameObject.GetComponent<PortalManager>();
        cam = GetComponentInChildren<Camera>();
    }
    void Update() 
    {
        portalCooldownLeft -= Time.deltaTime;
        if (portalCooldownLeft <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootPortal(0);
            }
            if (Input.GetButtonDown("Fire2"))
            {
                ShootPortal(1);
            }
        }
}


    void ShootPortal(int noPortal)
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            portalCooldownLeft = portalCooldown;
            if (hit.transform.tag == "Portable")
            {
                GameObject aTransform = new GameObject();
                aTransform.transform.position = hit.point;
                aTransform.transform.rotation = Quaternion.LookRotation(hit.normal);
                portalManager.CreatePortal(noPortal,aTransform.transform);
                Destroy(aTransform);
            }
        }
    }
}
