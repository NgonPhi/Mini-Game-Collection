using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LanderGameUI : MonoBehaviour
{
    [HideInInspector]
    public static LanderGameUI instance = null;

    public Text txtScore = null;
    public Text txtHealth = null;

    [Header("Game Over")]
    public GameObject panel = null;
    public Text txtScoreGO = null;
    public Text txtTitle = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        txtScore.text = LanderGame.instance.score.ToString();
        txtHealth.text = LanderGame.instance.health.ToString();
    }

    public void GameOver()
    {
        txtTitle.text = "Game Over !!!";
        txtScoreGO.text = LanderGame.instance.score.ToString();
        panel.SetActive(true);
    }

    public void WinGame()
    {
        txtScoreGO.text = LanderGame.instance.score.ToString();
        panel.SetActive(true);
    }
}
