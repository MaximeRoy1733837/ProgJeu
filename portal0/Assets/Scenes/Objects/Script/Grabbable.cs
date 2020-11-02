using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grabbable : MonoBehaviour
{
    private Rigidbody grabber;
    
    // Update is called once per frame
    void Update()
    {
        if(grabber!=null)
        {
            Move();
        }
    }
    
    public void Grab(Rigidbody grab)
    {
        grabber = grab;
        print("grab");
    }

    public void Release()
    {
        grabber = null;
        print("release");
    }

    private void Move()
    {
        //transform.position=
        print("Move");
    }

}
