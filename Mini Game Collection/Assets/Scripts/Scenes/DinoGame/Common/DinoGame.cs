using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoGame : MonoBehaviour
{
    public static DinoGame instance = null;

    [Header("Start Game")]
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float maxSpeed = 6f;

    public int Score { get { return score; } }
    public float Speed { get { return speed; } }

    [Header("Pawn Tree")]
    [SerializeField]
    private GameObject pawnPoint = null;
    [SerializeField]
    private GameObject tree = null;
    [SerializeField]
    private Vector2 timePawn = new Vector2(0.5f, 1.5f);

    private Vector3 startPos;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        startPos = pawnPoint.transform.position;
        StartCoroutine(PawnTree());
    }

    private void Update()
    {
        MovePawnPoint();
    }

    private void MovePawnPoint()
    {
        Vector3 pos = pawnPoint.transform.position;
        pos.x -= Time.deltaTime * speed;
        pawnPoint.transform.position = pos;
    }

    private IEnumerator PawnTree()
    {
        GameObject newTree = Instantiate(tree, startPos, Quaternion.identity);
        newTree.transform.parent = pawnPoint.transform;
        yield return new WaitForSeconds(Random.Range(timePawn.x, timePawn.y));
        StartCoroutine(PawnTree());
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        if (score % 10 == 0 && score != 0) speed += 0.5f;
        if (speed >= maxSpeed) speed = maxSpeed;
    }

    public void GameOver()
    {
        DinoGameUI.instance.GameOver();
        Time.timeScale = 0.0f;
    }
}
