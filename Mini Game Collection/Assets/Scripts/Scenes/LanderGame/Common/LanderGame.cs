using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderGame : MonoBehaviour
{
    public static LanderGame instance = null;

    [Header("Start Game")]
    [SerializeField]
    private int health = 5;
    [SerializeField]
    private int maxHealth = 10;
    [SerializeField]
    private int score = 0;

    public int Health { get { return health; } }
    public int Score { get { return score; } }

    [SerializeField]
    private GameObject SpaceShip = null;
    [SerializeField]
    private Transform startPoint = null;

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
            GameOver();
        }
    }

    private void GameOver()
    {
        LanderGameUI.instance.GameOver();
        Time.timeScale = 0.0f;
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

    public void ReStart()
    {
        SpaceShip.transform.position = startPoint.position;
    }

    public void WinGame()
    {
        LanderGameUI.instance.WinGame();
    }

}
