using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DinoGameUI : MonoBehaviour
{
    public static DinoGameUI instance = null;

    [SerializeField]
    private Text txtScore = null;
    [SerializeField]
    private Text txtSpeed = null;

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
        txtScore.text = DinoGame.instance.Score.ToString();
        txtSpeed.text = DinoGame.instance.Speed.ToString();
    }

    public void GameOver()
    {
        txtTitle.text = "Game Over !!!";
        txtScoreGO.text = DinoGame.instance.Score.ToString();
        panel.SetActive(true);
    }

}
