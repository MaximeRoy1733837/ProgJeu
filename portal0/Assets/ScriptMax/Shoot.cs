using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject portailBleuPrefab;
    public GameObject portailOrangePrefab;
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

            if (hit.transform.name == "mur 1" || hit.transform.name == "mur 2" || hit.transform.name == "mur 3" || hit.transform.name == "mur 4")
            {
                if (color == 1)
                {
                    GameObject bluePortal = Instantiate(portailBleuPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                    //Destroy(bluePortal);
                }
                else if (color == 2)
                {
                    GameObject orangePortal = Instantiate(portailOrangePrefab, hit.point, Quaternion.LookRotation(hit.normal));
                    //Destroy(orangePortal);
                }
            }      
        }
    }
}
