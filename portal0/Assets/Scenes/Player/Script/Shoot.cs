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

    public bool CanShoot { get; set; }

    void Start()
    {
        CanShoot = true;
        portalManager = gameObject.GetComponent<PortalManager>();
        cam = GetComponentInChildren<Camera>();
    }
    void Update() 
    {
        portalCooldownLeft -= Time.deltaTime;
        if (portalCooldownLeft <= 0 && CanShoot)
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
                if(hit.transform.GetComponent<Wall>()!=null)
                {
                    portalManager.CreatePortal(noPortal,aTransform.transform); 
                }
                else
                {
                    float rotation = 0;
                    if (Vector3.Dot(hit.transform.up, Vector3.down) > 0)
                    {
                        rotation = -gameObject.transform.rotation.eulerAngles.y;
                    }
                    else
                    {
                        rotation = gameObject.transform.rotation.eulerAngles.y + 180;
                    }
                        aTransform.transform.Rotate( new Vector3(0,0, rotation));
                    portalManager.CreatePortal(noPortal, aTransform.transform);
                }
                Destroy(aTransform);
            }
        }
    }
}
