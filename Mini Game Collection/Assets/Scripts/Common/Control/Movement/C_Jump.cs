using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Jump : DynPhy2DObject
{
    public KeyCode keyPress = KeyCode.Space;
    public float jumpStrength = 10f;
    public string groundTag = "Ground";
    public string trigger = "isJump";

    private bool canJump = true;

    private void Update()
    {
        if (Input.GetKey(keyPress) && canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            canJump = false;
            animator.SetTrigger(trigger);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(groundTag))
        {
            canJump = true;
        }
    }
}
