using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Push : Physics2DObject
{
    [SerializeField]
    private KeyCode keyPress = KeyCode.Space;
    [SerializeField]
    private float pushStrength = 5f;

    private void Update()
    {
        if (Input.GetKey(keyPress))
        {
            rigidbody2D.AddRelativeForce(Vector2.up * pushStrength);
        }
    }
}
