using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [HideInInspector]
    public Vector3 movementDirection;

    Rigidbody rb;

    public float walk_Speed = 5.0f;
    public float walk_Force = 50.0f;
    public float turning_Smoothing = 0.1f;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {

        //velocity we want to reach
        Vector3 targetVelocity = movementDirection * walk_Speed;


        //is the difference between target velocity and current velocity
        Vector3 deltaVelocity = targetVelocity - rb.velocity;

        if(rb.useGravity)
        {
            deltaVelocity.y = 0f;
        }

        rb.AddForce(deltaVelocity * walk_Force,ForceMode.Acceleration);

        Vector3 face_Direction = movementDirection;

        if(face_Direction == Vector3.zero)
        {
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            float rotationAngle = AngleAroundAxis(transform.forward, face_Direction, Vector3.up);

            rb.angularVelocity = (Vector3.up * rotationAngle * turning_Smoothing);
        }
    }

    float AngleAroundAxis(Vector3 dirA,Vector3 dirB,Vector3 axis)
    {
        float angle = Vector3.Angle(dirA,dirB);

        return angle * (Vector3.Dot(axis,Vector3.Cross(dirA,dirB)) > 0 ? 1 : -1);
    }
}
