using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderGame : MonoBehaviour
{
    [HideInInspector]
    public static LanderGame instance = null;

    [Header("Start Game")]
    public int health = 5;
    public int score = 0;

    public GameObject SpaceShip = null;
    public Transform startPoint = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        SpaceShip.transform.position = startPoint.position;
    }

    private void Update()
    {
        if (health == 0)
        {
            LanderGameUI.instance.GameOver();
            Time.timeScale = 0.0f;
        }
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

    public void ReStart()
    {
        SpaceShip.transform.position = startPoint.position;
    }

    public void WinGame()
    {
        LanderGameUI.instance.WinGame();
    }

}
