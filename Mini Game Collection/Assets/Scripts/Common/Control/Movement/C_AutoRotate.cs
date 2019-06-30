using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_AutoRotate : Physics2DObject
{
    [SerializeField]
    private float rotationSpeed = 5;

    private float currentRotation;

    private void FixedUpdate()
    {
        currentRotation += .02f * rotationSpeed * 10f;
        rigidbody2D.MoveRotation(-currentRotation);
    }
}
