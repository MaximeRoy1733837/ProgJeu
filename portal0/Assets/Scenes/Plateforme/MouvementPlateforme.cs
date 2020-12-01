using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPlateforme : MonoBehaviour
{
    public Vector3 movementVector = new Vector3(7f, 0f, 0f);
    public float period = 6f;

    public float time;
    private Vector3 positionDepart;
    private Vector3 velocity;

    void Start()
    {
        positionDepart = transform.position;

    }
    void Update()
    {
        UpdateTime();
        UpdateVelocity();
        UpdatePosition();
    }
    private void UpdatePosition()
    {
        transform.position += velocity;
    }
    private void UpdateTime()
    {
        time += Time.deltaTime;
    }
    private void UpdateVelocity()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        Vector3 offset = movementVector * rawSinWave;
        velocity = (positionDepart + offset) - transform.position;

    }
    public Vector3 GetVelocity()
    {
        return velocity;
    }
}
