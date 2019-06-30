using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBallGame : MonoBehaviour
{
    [HideInInspector]
    public static FootBallGame instance = null;

    public GameObject Player1 = null;
    public GameObject Player2 = null;
    public GameObject Ball = null;

    [Header("Start Game")]
    public int timeStart = 3;

    [Header("Win Game")]
    public ParticleSystem confetti = null;    
    public int timeResume = 3;

    private Vector3 posStartPlayer1 = new Vector3();
    private Vector3 posStartPlayer2 = new Vector3();
    private Vector3 posStartBall = new Vector3();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        posStartPlayer1 = Player1.transform.position;
        posStartPlayer2 = Player2.transform.position;
        posStartBall = Ball.transform.position;

        StartCoroutine(FootBallGameUI.instance.StartGame(timeStart));
        StartCoroutine(RePosStart());
    }    

    public void WinGame(string player)
    {
        //Debug.Log(player + " Win !!!");
        if (player.Equals("Player1"))
        {
            Player1.GetComponent<M_Player>().IncreaseScore(1);
            StartCoroutine(FootBallGameUI.instance.WinGame("Player 1", timeResume));
        }
        else if(player.Equals("Player2"))
        {
            Player2.GetComponent<M_Player>().IncreaseScore(1);
            StartCoroutine(FootBallGameUI.instance.WinGame("Player 2", timeResume));
        }

        confetti.Play();
        StartCoroutine(RePosStart());
    }

    IEnumerator RePosStart()
    {
        Player1.GetComponent<C_Move>().rigidbody2D.bodyType = RigidbodyType2D.Static;
        Player2.GetComponent<C_Move>().rigidbody2D.bodyType = RigidbodyType2D.Static;
        Ball.GetComponent<C_Ball>().rigidbody2D.bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(timeResume);

        Ball.transform.position = posStartBall;
        Player1.transform.position = posStartPlayer1;
        Player2.transform.position = posStartPlayer2;
        Ball.GetComponent<C_Ball>().rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Player1.GetComponent<C_Move>().rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Player2.GetComponent<C_Move>().rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

}
