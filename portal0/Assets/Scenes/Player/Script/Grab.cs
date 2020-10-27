using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public float grabDistance = 1f;
    void Update()
    {
        
        if(Input.GetKeyUp("e"))
        {
            PickUp();
        }
    }
    void PickUp()
    { }
}
