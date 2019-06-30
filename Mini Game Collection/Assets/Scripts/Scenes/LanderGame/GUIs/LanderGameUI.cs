using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LanderGameUI : MonoBehaviour
{
    public static LanderGameUI instance = null;

    [SerializeField]
    private Text txtScore = null;
    [SerializeField]
    private Text txtHealth = null;

    [Header("Game Over")]
    [SerializeField]
    private GameObject panel = null;
    [SerializeField]
    private Text txtScoreGO = null;
    [SerializeField]
    private Text txtTitle = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        txtScore.text = LanderGame.instance.Score.ToString();
        txtHealth.text = LanderGame.instance.Health.ToString();
    }

    public void GameOver()
    {
        txtTitle.text = "Game Over !!!";
        txtScoreGO.text = LanderGame.instance.Score.ToString();
        panel.SetActive(true);
    }

    public void WinGame()
    {
        txtScoreGO.text = LanderGame.instance.Score.ToString();
        panel.SetActive(true);
    }
}
