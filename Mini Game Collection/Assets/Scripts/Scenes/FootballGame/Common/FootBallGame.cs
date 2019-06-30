using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBallGame : MonoBehaviour
{
    public static FootBallGame instance = null;

    [SerializeField]
    private GameObject player1 = null;
    [SerializeField]
    private GameObject player2 = null;
    [SerializeField]
    private GameObject ball = null;

    public GameObject Player1 { get { return player1; } }
    public GameObject Player2 { get { return player2; } }

    [Header("Start Game")]
    [SerializeField]
    private int timeStart = 3;

    [Header("Win Game")]
    [SerializeField]
    private ParticleSystem confetti = null;
    [SerializeField]
    private int timeResume = 3;

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
        posStartPlayer1 = player1.transform.position;
        posStartPlayer2 = player2.transform.position;
        posStartBall = ball.transform.position;

        StartCoroutine(FootBallGameUI.instance.StartGame(timeStart));
        StartCoroutine(RePosStart());
    }

    public void WinGame(string player)
    {
        if (player.Equals("Player1"))
        {
            player1.GetComponent<M_Player>().IncreaseScore(1);
            StartCoroutine(FootBallGameUI.instance.WinGame("Player 1", timeResume));
        }
        else if (player.Equals("Player2"))
        {
            player2.GetComponent<M_Player>().IncreaseScore(1);
            StartCoroutine(FootBallGameUI.instance.WinGame("Player 2", timeResume));
        }

        confetti.Play();
        StartCoroutine(RePosStart());
    }

    private IEnumerator RePosStart()
    {
        player1.GetComponent<C_Move>().rigidbody2D.bodyType = RigidbodyType2D.Static;
        player2.GetComponent<C_Move>().rigidbody2D.bodyType = RigidbodyType2D.Static;
        ball.GetComponent<C_Ball>().rigidbody2D.bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(timeResume);

        ball.transform.position = posStartBall;
        player1.transform.position = posStartPlayer1;
        player2.transform.position = posStartPlayer2;
        ball.GetComponent<C_Ball>().rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        player1.GetComponent<C_Move>().rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        player2.GetComponent<C_Move>().rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

}
