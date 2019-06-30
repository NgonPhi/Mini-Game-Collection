using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DefenderGameUI : MonoBehaviour
{
    public static DefenderGameUI instance = null;

    [SerializeField]
    private Text txtScore = null;
    [SerializeField]
    private Text txtHealth = null;
    
    [Header("Game Over")]
    [SerializeField]
    private GameObject panel = null;
    [SerializeField]
    private Text txtScoreGO = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        txtScore.text = DefenderGame.instance.Score.ToString();
        txtHealth.text = DefenderGame.instance.Health.ToString();
    }

    public void GameOver()
    {
        txtScoreGO.text = DefenderGame.instance.Score.ToString();
        panel.SetActive(true);
    }

}
