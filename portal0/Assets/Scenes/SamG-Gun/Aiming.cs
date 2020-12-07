using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Transform CamPos;

    public Transform ArmPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Aim = ArmPrefab.rotation.z + CamPos.rotation.x;

        ArmPrefab.Rotate(ArmPrefab.rotation.x, ArmPrefab.rotation.y, Aim);
    }
}
