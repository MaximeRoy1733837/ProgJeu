﻿using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCamera : MonoBehaviour
{
    private Rigidbody body;
    private Rigidbody cam;
    private float cameraHorizontalSpeed = 2f;
    private float cameraVerticalSpeed = 2f;
    private float cameraH = 0f;
    private float cameraV = 0f;

    public bool CanLook { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        CanLook = true;
        body = GameObject.Find("Player").GetComponent<Rigidbody>();
        cam = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanLook)
        {
            ChangeCameraDirection();
        }
    }

    void ChangeCameraDirection()
    {
        cameraH += cameraHorizontalSpeed * Input.GetAxis("Mouse X");
        cameraV -= cameraVerticalSpeed * Input.GetAxis("Mouse Y");
        // Fait en sorte que la camera peut seulement regarder 90 degree en l'air et vers le bas
        cameraV = Mathf.Clamp(cameraV, -90f, 90f);
        cam.MoveRotation(Quaternion.Euler(new Vector3(cameraV, cameraH, 0f)));
        body.MoveRotation(Quaternion.Euler(new Vector3(0, cameraH, 0)));
    }

    public void setCameraRotation()
    {
        cameraH = gameObject.transform.rotation.y;
        cameraV = gameObject.transform.rotation.x;

    }
}
