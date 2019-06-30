using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DinoGameUI : MonoBehaviour
{
    [HideInInspector]
    public static DinoGameUI instance = null;

    public Text txtScore = null;
    public Text txtSpeed = null;

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
        txtScore.text = DinoGame.instance.score.ToString();
        txtSpeed.text = DinoGame.instance.speed.ToString();
    }

    public void GameOver()
    {
        txtTitle.text = "Game Over !!!";
        txtScoreGO.text = DinoGame.instance.score.ToString();
        panel.SetActive(true);
    }

}
