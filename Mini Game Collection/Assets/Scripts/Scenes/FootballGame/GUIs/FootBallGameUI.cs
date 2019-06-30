using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FootBallGameUI : MonoBehaviour
{
    [HideInInspector]
    public static FootBallGameUI instance = null;

    public Text txtScore1 = null;
    public Text txtScore2 = null;

    [Header("Win Game")]
    public GameObject Panel = null;
    public Text txtWinner = null;
    public Text txtTimeResume = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public IEnumerator StartGame(int timeDelay)
    {
        txtScore1.text = FootBallGame.instance.Player1.GetComponent<M_Player>().Score.ToString();
        txtScore2.text = FootBallGame.instance.Player2.GetComponent<M_Player>().Score.ToString();
        txtWinner.text = "Ready !!!";

        Panel.SetActive(true);
        for (int t = timeDelay; t >= 0; t--)
        {
            txtTimeResume.text = t.ToString();
            yield return new WaitForSeconds(1);
        }
        Panel.SetActive(false);
    }

    public IEnumerator WinGame(string player, int timeDelay)
    {
        txtScore1.text = FootBallGame.instance.Player1.GetComponent<M_Player>().Score.ToString();
        txtScore2.text = FootBallGame.instance.Player2.GetComponent<M_Player>().Score.ToString();
        txtWinner.text = player + " Win !!!";
        txtTimeResume.text = timeDelay.ToString();

        Panel.SetActive(true);
        for (int t = timeDelay; t >= 0; t--)
        {
            txtTimeResume.text = t.ToString();
            yield return new WaitForSeconds(1);
        }
        Panel.SetActive(false);
    }
}
