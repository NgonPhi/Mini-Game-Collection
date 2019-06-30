using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public static LoadGame instance = null;

    [Header("Load Game")]
    [SerializeField]
    private float timeLoad = 5.0f;

    private float timer;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        LoadGameUI.instance.LoadGame(Time.deltaTime / timeLoad);
        if (timer >= timeLoad)
            GetComponent<ScenesManager>().ChangeScene("MenuGame");
    }
}
