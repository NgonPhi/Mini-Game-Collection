using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Rotate : Physics2DObject
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    private float spin;

    private void Update()
    {
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        {
            spin = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            spin = Input.GetAxisRaw("Horizontal2");
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.AddTorque(-spin * speed); // Tạo torque (mô mem xoắn) tại tâm
    }
}
