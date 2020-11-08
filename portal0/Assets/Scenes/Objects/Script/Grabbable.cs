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
    private float weight;
    private CollisionDetectionMode collisionMode;
    public float Weight { get { return weight; } }

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        drag = myRigidbody.drag;
        weight = myRigidbody.mass;
        collisionMode = myRigidbody.collisionDetectionMode;
    }
    void Update()
    {
        if(grabber!=null)
        {
            Move();
            Rotate();
        }
    }

    public void Grab(Grab aGrabber)
    {
        grabber = aGrabber;
        myRigidbody.drag = 20;
        myRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
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
        myRigidbody.collisionDetectionMode = collisionMode;
    }  
    //use when a thirdparty want to release the item
    public void ForceRelease()
    {
        if (grabber != null)
        {
            grabber.ForceRelease();
        }
        Release();
    }

    private void Move()
    {
        Vector3 vector3 = myRigidbody.position - grabber.GetDestination();
        float aForce = force / weight;
        if(aForce>force)
        {
            aForce = force;
        }
        myRigidbody.AddForce(-vector3*aForce,ForceMode.VelocityChange);
    }

    private void Rotate()
    {
        myRigidbody.rotation=Quaternion.RotateTowards(myRigidbody.rotation,grabber.transform.rotation,5);
    }

    public void Trow(Vector3 direction)
    {
        myRigidbody.AddForce(direction, ForceMode.VelocityChange);
    }

}
