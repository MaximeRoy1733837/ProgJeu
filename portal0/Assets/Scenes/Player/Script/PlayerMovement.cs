using System.Collections;
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


    private float walkSpeed = 10f;
    private float jumpHeight = 5f;
    private float minSpeed = 100f;

    private int numberOfJumps = 20;

    private int jumpsUsed = 0; 



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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(forward))
        {
            Vector3 walkVelocity = new Vector3(transform.forward.x, 0.1f, transform.forward.z);
            body.AddForce(walkVelocity*walkSpeed, ForceMode.Acceleration);
        } 
        if(Input.GetKey(backward))
        {
            Vector3 walkVelocity = new Vector3( -transform.forward.x, 0.1f, -transform.forward.z);
            body.AddForce(walkVelocity*walkSpeed, ForceMode.Acceleration);
        } 
        if(Input.GetKey(right))
        {
            Vector3 walkVelocity = new Vector3(transform.right.x, 0.1f, transform.right.z);
            body.AddForce(walkVelocity*walkSpeed, ForceMode.Acceleration);
        } 
        if(Input.GetKey(left))
        {
            Vector3 walkVelocity = new Vector3(-transform.right.x, 0.1f, -transform.right.z);
            body.AddForce(walkVelocity*walkSpeed, ForceMode.Acceleration);
        }
        if(Input.GetKeyDown(Jump)&&jumpsUsed<numberOfJumps)
        {
            jumpsUsed++;
            Vector3 jumpVelocity = new Vector3(0, (jumpHeight * 50 /body.mass)+Mathf.Abs(body.velocity.y), 0);
            body.AddForce(jumpVelocity, ForceMode.Impulse);
        }

    }

}
