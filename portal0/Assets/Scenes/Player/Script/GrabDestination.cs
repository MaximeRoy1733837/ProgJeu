using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDestination : MonoBehaviour
{
    private Rigidbody body;
    public Vector3 destination { get { return transform.position; } }

    private void Start()
    {
        body = GetComponentInParent<Rigidbody>();
    }
    public void ChangeDistance(float distance)
    {
        transform.localPosition = new Vector3(0,0,distance);
    }
}
