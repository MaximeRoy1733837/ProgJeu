using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DestroyOnHit : MonoBehaviour
{


     void OnCollisionEnter(Collision col)
     {
        if(col.gameObject.name == "BubbleLaser1")
        {
                Destroy(col.gameObject);
        }
     }
}
