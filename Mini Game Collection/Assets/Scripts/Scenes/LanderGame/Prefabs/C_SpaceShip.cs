using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SpaceShip : MonoBehaviour
{
    public GameObject ef = null;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Planet"))
        {
            Instantiate(ef, transform.position, Quaternion.identity);
            LanderGame.instance.IncreaseHealth(-1);
            LanderGame.instance.ReStart();
        }
        if (other.collider.CompareTag("EndPoint"))
        {
            LanderGame.instance.IncreaseScore(1);
            LanderGame.instance.WinGame();
        }
    }
}
