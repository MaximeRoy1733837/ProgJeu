using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootPortal(1);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ShootPortal(2);
        }
    }

    void ShootPortal(int color)
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }

    }
}
