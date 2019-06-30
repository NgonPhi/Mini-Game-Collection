using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Planet : MonoBehaviour
{
    private M_Planet planet = null;
    public GameObject ef = null;

    private void Start()
    {
        planet = GetComponent<M_Planet>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            DefenderGame.instance.IncreaseScore(planet.Score);
            Instantiate(ef, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
            DefenderGame.instance.IncreaseHealth(-planet.Power);
            Instantiate(ef, transform.position, Quaternion.identity);
        }
    }
}
