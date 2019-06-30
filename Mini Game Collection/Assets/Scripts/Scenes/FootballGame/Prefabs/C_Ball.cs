using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Ball : Physics2DObject
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Goal1"))
        {
            FootBallGame.instance.WinGame("Player2");
        }
        else if(other.collider.CompareTag("Goal2"))
        {
            FootBallGame.instance.WinGame("Player1");
        }        
    }
}
