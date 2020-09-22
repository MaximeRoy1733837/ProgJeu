using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController characterController;
    private Vector3 characterMoveDirection;
    private float characterSpeed = 6f;
    private float characterJumpSpeed = 8f;
    private float gravityForce = 20f;

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
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
