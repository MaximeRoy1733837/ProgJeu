using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public float grabDistance = 5f;
    public Camera cam;

    private Grabbable grabbedItem { get; set; }

    private KeyCode grab = KeyCode.E;
    

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
                grabbedItem.Grab(cam.GetComponent<Rigidbody>());
            }
        }
    }
}
