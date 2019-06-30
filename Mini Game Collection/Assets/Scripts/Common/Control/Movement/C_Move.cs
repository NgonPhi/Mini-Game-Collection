using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Move : Physics2DObject
{
    public float speed = 5f;
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    private Vector2 movement;
    private float moveHoz;
    private float moveVer;

    private void Update()
    {
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        {
            moveHoz = Input.GetAxisRaw("Horizontal");
            moveVer = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveHoz = Input.GetAxisRaw("Horizontal2");
            moveVer = Input.GetAxisRaw("Vertical2");
        }
        movement = new Vector2(moveHoz, moveVer);
    }

    private void FixedUpdate()
    {
        rigidbody2D.AddForce(movement * speed * 10f);
    }

}
