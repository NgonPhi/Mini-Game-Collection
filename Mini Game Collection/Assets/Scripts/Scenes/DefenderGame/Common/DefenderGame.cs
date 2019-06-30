using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderGame : MonoBehaviour
{
    [HideInInspector]
    public static DefenderGame instance = null;

    [Header("Start Game")]
    public int health = 5;
    public int score = 0;

    [Header("Pawn Planet")]
    public Transform posPawn = null;
    public GameObject[] planets = null;
    public float timePawn = 1f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        StartCoroutine(PawnPlanet());
    }

    private void Update()
    {
        if(health == 0)
        {
            DefenderGameUI.instance.GameOver();
            Time.timeScale = 0.0f;
        }
    }

    IEnumerator PawnPlanet()
    {
        int randomIndex = Random.Range(0, planets.Length);
        GameObject newObj = Instantiate(planets[randomIndex]);
        Vector3 pos = posPawn.position;
        pos.x = Random.Range(-posPawn.position.x, posPawn.position.x);
        newObj.transform.position = pos;

        yield return new WaitForSeconds(timePawn);
        StartCoroutine(PawnPlanet());
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
        if (health <= 0) health = 0;
    }
}
