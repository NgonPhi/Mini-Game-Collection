using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Player: MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    public int Score { get { return score; } }

    public void IncreaseScore(int amount)
    {        
        score += amount;
    }
}
