﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody body;
    private PlayerCamera playerCamera;
    public Animator anim;


    private float walkSpeed = 10f;
    private float jumpHeight = 5f;

    private int numberOfJumps = 20;
    private int jumpsUsed = 0;
    private bool isGrounded;

    public bool IsGrounded { get { return isGrounded; } }

    //pour si on change les touches
    private KeyCode forward = KeyCode.W;
    private KeyCode backward = KeyCode.S;
    private KeyCode left = KeyCode.A;
    private KeyCode right = KeyCode.D;
    private KeyCode Jump = KeyCode.Space;
    void Start()
    {
       // characterController = gameObject.GetComponent<CharacterController>();
        body = gameObject.GetComponent<Rigidbody>();
        
        playerCamera = gameObject.GetComponentInChildren<PlayerCamera>();
        anim.SetFloat("moving", 0);
        anim.SetBool("Jumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        Inputs();
    }

    private void Inputs()
    {
        if (Input.GetKey(forward))
        {
            Vector3 walkVelocity = new Vector3(transform.forward.x, 0.1f, transform.forward.z);
            body.AddForce(walkVelocity * walkSpeed, ForceMode.Acceleration);
            anim.SetFloat("moving", 1);
            
        }
        if (Input.GetKey(backward))
        {
            Vector3 walkVelocity = new Vector3(-transform.forward.x, 0.1f, -transform.forward.z);
            body.AddForce(walkVelocity * walkSpeed, ForceMode.Acceleration);
            anim.SetFloat("moving", 1);
        }
        if (Input.GetKey(right))
        {
            Vector3 walkVelocity = new Vector3(transform.right.x, 0.1f, transform.right.z);
            body.AddForce(walkVelocity * walkSpeed, ForceMode.Acceleration);
            anim.SetFloat("moving", 1);
        }
        if (Input.GetKey(left))
        {
            Vector3 walkVelocity = new Vector3(-transform.right.x, 0.1f, -transform.right.z);
            body.AddForce(walkVelocity * walkSpeed, ForceMode.Acceleration);
            anim.SetFloat("moving", 1);           
        }
        if (Input.GetKeyDown(Jump) && jumpsUsed < numberOfJumps)
        {
            jumpsUsed++;
            Vector3 jumpVelocity = new Vector3(0, (jumpHeight * 50 / body.mass) + Mathf.Abs(body.velocity.y), 0);
            body.AddForce(jumpVelocity, ForceMode.Impulse);
            anim.SetBool("Jumping", true);
        }
        //anim.SetFloat("moving", 0);
        //anim.SetBool("Jumping", false);
    }
    private void CheckIfGrounded()
    {
        //if()
    }
}
