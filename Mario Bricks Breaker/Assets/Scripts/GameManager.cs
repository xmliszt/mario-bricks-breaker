using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text score1;
    public TMP_Text score2;
    public TMP_Text endScore1;
    public TMP_Text endScore2;
    public TMP_Text winnerText;

    public GameObject startScreen;
    public GameObject scoreScreen;
    public GameObject endScreen;

    public GameObject obstacle;
    public float obstacleExistDuration;
    public float obstacleHideDuration;
    public int endScore;

    private bool gameStarted;
    private int player1Score;
    private int player2Score;
    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        obstacle.SetActive(false);
        scoreScreen.SetActive(false);
        endScreen.SetActive(false);
        obstacle.transform.localScale = new Vector3(0, 0, 0);
        player1Score = 0;
        player2Score = 0;
        SetScore1Text();
        SetScore2Text();
    }

    private void Update()
    {
        if (gameStarted && player1Score >= endScore)
        {
            winnerText.text = "Winner: Player 1";
            GameOver();
        }
        else if (gameStarted && player2Score >= endScore)
        {
            winnerText.text = "Winner: Player 2";
            GameOver();
        }
    }

    private void StartLoopObstacle()
    {
        InvokeRepeating("ShowObstacle", obstacleHideDuration, obstacleExistDuration + obstacleHideDuration);
        InvokeRepeating("HideObstacle", obstacleHideDuration + obstacleExistDuration, obstacleExistDuration + obstacleHideDuration);
    }

    public void SetScore1Text()
    {
        score1.text = "Player 1: " + player1Score;    
        endScore1.text = "Player 1: " + player1Score;
    }

    public void SetScore2Text()
    {
        score2.text = "Player 2: " + player2Score;
        endScore2.text = "Player 2: " + player2Score;
    }

    public void AddScore1(int score)
    {
        player1Score += score;
        SetScore1Text();
    }

    public void AddScore2(int score)
    {
        player2Score += score;
        SetScore2Text();
    }

    public int GetScore1()
    {
        return player1Score;
    }

    public int GetScore2()
    {
        return player2Score;
    }

    public void ShowObstacle()
    {
        StartCoroutine(EnlargeObstacle());
    }

    public void HideObstacle()
    {
        StartCoroutine(ShrinkObstacle());
    }

    IEnumerator EnlargeObstacle()
    {
        obstacle.SetActive(true);
        while (obstacle.transform.localScale.x < 1)
        {
            yield return new WaitForSeconds(0.01f);
            obstacle.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    IEnumerator ShrinkObstacle()
    {
        while (obstacle.transform.localScale.x > 0)
        {
            yield return new WaitForSeconds(0.01f);
            obstacle.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
        obstacle.SetActive(false);
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }

    public void Home()
    {
        startScreen.SetActive(true);
        scoreScreen.SetActive(false);
        endScreen.SetActive(false);
        player1Score = 0;
        player2Score = 0;
        CancelInvoke();
    }

    public void GameOver()
    {
        gameStarted = false;
        endScreen.SetActive(true);
        CancelInvoke();
    }

    public void StartGame()
    {
        gameStarted = true;
        startScreen.SetActive(false);
        scoreScreen.SetActive(true);
        endScreen.SetActive(false);
        StartLoopObstacle();
    }
}
