using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public float trowForce = 50f;
    public Camera cam;

    private GrabDestination grabDestination;
    private float grabDistance = 5f;

    private Grabbable grabbedItem { get; set; }
    public Vector3 GrabDestination 
    {
        get { return grabDestination.destination; }
    }

    private KeyCode grab = KeyCode.E;
    private KeyCode trow = KeyCode.R;
    

    private void Start()
    {
        grabDestination = cam.GetComponentInChildren<GrabDestination>();
    }

    void Update()
    {
        if(Input.GetKeyUp(grab))
        {
            if(grabbedItem==null)
            {
                PickUp();
            }
            else
            {
                grabbedItem.Release();
                grabbedItem = null;
            }
        }

        if(grabbedItem!=null)
        {
            if(Input.GetAxis("Mouse ScrollWheel")!=0f)
            {
                ChangeGrabDistance(Input.GetAxis("Mouse ScrollWheel")*5);
            }

            if (Input.GetKeyUp(trow))
            {
                Trow();
            }
        }
    }
    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, grabDistance))
        {
            Grabbable item = hit.transform.GetComponent<Grabbable>();
            if (item != null)
            {
                grabbedItem = item;
                grabbedItem.Grab(this);
            }
        }
    }
    public Vector3 GetDestination()
    {
        return grabDestination.destination;
    }

    public void Release()
    { 
        grabbedItem = null;
    } 
    public void ForceRelease()
    {
        if (grabbedItem != null)
        {
            grabbedItem.ForceRelease();
            grabbedItem = null;
        }
    }

    public void ChangeGrabDistance(float toAdd)
    {
        grabDistance += toAdd;
        UpdateGrabDistance();
    }
    private void UpdateGrabDistance() 
    {
        grabDestination.ChangeDistance(grabDistance);
    }

    private void Trow()
    {
        grabbedItem.Release();
        Vector3 direction = cam.transform.forward*trowForce;
        grabbedItem.Trow(direction);
        Release();
    }
}
