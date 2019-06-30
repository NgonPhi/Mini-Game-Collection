using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoGame : MonoBehaviour
{
    [HideInInspector]
    public static DinoGame instance = null;

    [Header("Start Game")]
    public int score = 0;

    public float speed = 3f;
    public GameObject pawnPoint = null;
    public GameObject tree = null;
    public Vector2 timePawn = new Vector2(0.5f, 1.5f);

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

    IEnumerator PawnTree()
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
    }

    public void GameOver()
    {
        DinoGameUI.instance.GameOver();
        Time.timeScale = 0.0f;
    }
}
