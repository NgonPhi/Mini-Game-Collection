using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadGameUI : MonoBehaviour
{
    [HideInInspector]
    public static LoadGameUI instance = null;

    [Header("Load Game")]
    public RectTransform canvas = null;
    public Image imgLoad = null;
    public GameObject rollingBall = null;

    private float maxX;
    private float sumValue = 0.0f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        imgLoad.fillAmount = 0;
        maxX = canvas.rect.width;
    }

    public void LoadGame(float value)
    {
        sumValue += value;
        if (sumValue >= 1) return;
        imgLoad.fillAmount += value;
        Vector3 pos = rollingBall.transform.position;
        pos.x += value * maxX;
        rollingBall.transform.position = pos;
    }

}
