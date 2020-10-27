using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private CharacterController characterController;
    private GameObject cameraOverlayBlood;
    private float cameraHorizontalSpeed = 2f;
    private float cameraVerticalSpeed = 2;
    private float cameraYaw = 0f;
    private float cameraPitch = 0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
        cameraOverlayBlood = GameObject.Find("OverlayCamera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCameraDirection();
    }

    void ChangeCameraDirection()
    {
        cameraYaw += cameraHorizontalSpeed * Input.GetAxis("Mouse X");
        cameraPitch -= cameraVerticalSpeed * Input.GetAxis("Mouse Y");

        // Fait en sorte que la camera peut seulement regarder 90 degree en l'air et vers le bas
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        transform.eulerAngles = new Vector3(cameraPitch, cameraYaw, 0f);
        characterController.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
    }
}
