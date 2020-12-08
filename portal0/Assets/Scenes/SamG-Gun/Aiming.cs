using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Transform CamPos;

    public Transform ArmPrefab;

    // Update is called once per frame
    void Update()
    {
        float Aim = ArmPrefab.rotation.z + CamPos.rotation.x;

        ArmPrefab.Rotate(ArmPrefab.rotation.x, ArmPrefab.rotation.y, Aim);
    }
}
