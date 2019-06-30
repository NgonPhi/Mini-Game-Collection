using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DefenderGameUI : MonoBehaviour
{
    [HideInInspector]
    public static DefenderGameUI instance = null;

    public Text txtScore = null;
    public Text txtHealth = null;

    [Header("Game Over")]
    public GameObject panel = null;
    public Text txtScoreGO = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        txtScore.text = DefenderGame.instance.score.ToString();
        txtHealth.text = DefenderGame.instance.health.ToString();
    }

    public void GameOver()
    {
        txtScoreGO.text = DefenderGame.instance.score.ToString();
        panel.SetActive(true);
    }    

}
