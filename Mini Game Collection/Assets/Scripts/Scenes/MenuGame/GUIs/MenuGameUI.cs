using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGameUI : MonoBehaviour
{
    private ScenesManager scenesManager = null;

    private void Awake()
    {
        scenesManager = GetComponent<ScenesManager>();
    }

    public void ChangeScene(string name)
    {
        scenesManager.ChangeScene(name);
    }
}
