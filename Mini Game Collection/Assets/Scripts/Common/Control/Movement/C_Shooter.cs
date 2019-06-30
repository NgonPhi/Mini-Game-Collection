using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Shooter : MonoBehaviour
{
    public KeyCode keyPress = KeyCode.Space;
    public GameObject bullet = null;
    public float shootSpeed = 10f;
    public float creationRate = 0.5f;

    private float timeOfLastSpawn;

    private void Start()
    {
        timeOfLastSpawn = -creationRate;
    }

    private void Update()
    {
        if (Input.GetKey(keyPress) && Time.time >= timeOfLastSpawn + creationRate)
        {
            GameObject newObject = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null)
            {
                rigidbody2D.AddRelativeForce(Vector2.up * shootSpeed * 50);
            }

            timeOfLastSpawn = Time.time;
        }
    }
}
