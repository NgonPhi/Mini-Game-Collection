using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Tree : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("DiePoint"))
        {
            Destroy(gameObject);
            DinoGame.instance.IncreaseScore(1);
        }
        if (other.collider.CompareTag("Player"))
        {
            DinoGame.instance.GameOver();
        }
    }
}
