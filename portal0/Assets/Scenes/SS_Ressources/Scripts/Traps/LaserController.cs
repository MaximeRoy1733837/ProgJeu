using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public bool canMove = true;
    public ELaserMovementState state;
    public float timeToRotate = 2f;

    void Start()
    {
    }

    void Update()
    {
        if (canMove)
            CalculateMovement();
    }

    private void CalculateMovement() {

        switch (state) {
            case ELaserMovementState.None:
                break;
            case ELaserMovementState.Horizontal360Degrees:
                MoveHorizontalByValue(360f);
                break;
            case ELaserMovementState.Vertical360Degrees:
                MoveVerticalByValue(360f);
                break;
            case ELaserMovementState.Random:
                MoveRandom();
                break;
            default:
                break;
        }
    }

    private void MoveHorizontalByValue(float aMovingAngle) {

        float degreePerSeconds = (transform.root.eulerAngles.y + aMovingAngle) / timeToRotate;
        transform.root.Rotate(new Vector3(0, degreePerSeconds * Time.deltaTime, 0));
    }

    private void MoveVerticalByValue(float aMovingAngle) {

        float degreePerSeconds = (transform.root.eulerAngles.x + aMovingAngle) / timeToRotate;
        transform.root.Rotate(new Vector3(degreePerSeconds * Time.deltaTime, 0, 0));
    }

    private void MoveRandom() {

        int movementAxis = Random.Range(0, 1);
        float movementAngle = Random.Range(0, 360);
        //print("Axis: " + movementAxis + ", Angle: " + movementAngle);

        switch (movementAxis) {
            case 0: //Horizontal
                MoveHorizontalByValue(movementAngle);
                break;
            case 1: //Vertical
                MoveVerticalByValue(movementAngle);
                break;
            default:
                break;
        }

    }
}
