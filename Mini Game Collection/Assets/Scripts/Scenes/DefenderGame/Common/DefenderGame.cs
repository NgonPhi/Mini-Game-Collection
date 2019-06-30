using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderGame : MonoBehaviour
{
    public static DefenderGame instance = null;

    [Header("Start Game")]
    [SerializeField]
    private int health = 5;    
    [SerializeField]
    private int maxHealth = 10;
    [SerializeField]
    private int score = 0;

    public int Health { get { return health; } }
    public int Score { get { return score; } }

    [Header("Pawn Planet")]
    [SerializeField]
    private Transform posPawn = null;
    [SerializeField]
    private GameObject[] planets = null;
    [SerializeField]
    private float timePawn = 1f;

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
            GameOver();
        }
    }

    private void GameOver()
    {
        DefenderGameUI.instance.GameOver();
        Time.timeScale = 0.0f;
    }

    private IEnumerator PawnPlanet()
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
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
