using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grabbable : MonoBehaviour
{
    private Grab grabber;
    public float force=5;

    private float drag;
    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        drag = myRigidbody.drag;
    }
    void Update()
    {
        if(grabber!=null)
        {
            Move();
        }
    }

    public void Grab(Grab aGrabber)
    {
        grabber = aGrabber;
        myRigidbody.drag = 20;
        force =20/ myRigidbody.mass;
        if(force>20)
        {
            force = 20;
        }
    }

    public void Release()
    {
        grabber = null;
        myRigidbody.drag = drag;
    }  
    public void ForceRelease()
    {
        if (grabber != null)
        {
            grabber.ForceRelease();
            grabber = null;
        }
        myRigidbody.drag = drag;
    }

    private void Move()
    {
        Vector3 vector3 = myRigidbody.position - grabber.GetDestination();
        myRigidbody.AddForce(-vector3*force,ForceMode.VelocityChange);
    }

    public void Trow(Vector3 direction)
    {
        myRigidbody.AddForce(direction, ForceMode.VelocityChange);
    }

}
