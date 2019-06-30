using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Planet : MonoBehaviour
{
    [SerializeField]
    private int score = 1;
    [SerializeField]
    private int power = 1;

    public int Score { get { return score; } }
    public int Power { get { return power; } }
}
