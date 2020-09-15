using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float maxSpeed = 7;

    private Vector2 targetVelocity;
    public GameObject preFabPortal;
    private bool notdone = true;

    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Fire1")!=0 && notdone)
        {
            Instantiate(preFabPortal, new Vector3(-3f, 1f, -3f), Quaternion.Euler(0, 90, 0));
            notdone = false;
        }

    }
  
}
