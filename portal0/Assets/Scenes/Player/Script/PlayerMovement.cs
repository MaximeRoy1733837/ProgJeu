using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController characterController;
    private PlayerCamera playerCamera;
    private Vector3 characterMoveDirection;
    private float characterSpeed = 6f;
    private float characterJumpSpeed = 8f;
    private float gravityForce = 20f;

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        playerCamera = gameObject.GetComponentInChildren<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            characterMoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            characterMoveDirection = transform.TransformDirection(characterMoveDirection);
            characterMoveDirection *= characterSpeed;

            if (Input.GetButton("Jump")) {

                characterMoveDirection.y = characterJumpSpeed;
            }
        }
        characterMoveDirection.y -= gravityForce * Time.deltaTime;
        characterController.Move(characterMoveDirection * Time.deltaTime);
    }

}
