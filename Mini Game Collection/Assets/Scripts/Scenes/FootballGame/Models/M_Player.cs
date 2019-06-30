using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Player: MonoBehaviour
{
    private int score = 0;
    public int Score { get { return score; } set { score = value; } }

    public void IncreaseScore(int amount)
    {        
        Score += amount;
    }
}
