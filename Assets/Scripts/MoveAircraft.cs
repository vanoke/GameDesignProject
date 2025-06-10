using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAircraft : MonoBehaviour
{
    private Rigidbody Rigidbodyrb;
    public float Speed = 5.0f; // Aircraft speed
    public float RotationSpeed = 1.0f; // Aircraft rotation speed

    void Start()
    {
        Rigidbodyrb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * RotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * Speed;

        Rigidbodyrb.AddRelativeForce(0f, 0f, forwardForce);
        Rigidbodyrb.AddRelativeTorque(0f, sideForce, 0f);
    }
}