using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Scroll_BackGround : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 20f;

    private float countDis = 0f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        countDis += Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);

        if(countDis >= distance)
        {
            transform.position = startPos;
            countDis = 0f;
        }
    }
}
