using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    private int playerScore = 0;
    public Text ScoreText;
    public Text HiScoreText;
    public HiScore SavedScore;

    private void Start()
    {
        HiScoreText.text = SavedScore.HiScoreText;
    }

    private void OnEnable()
    {
        EnemyController.dead += AddScore;
    }

    private void OnDisable()
    {
        EnemyController.dead -= AddScore;
    }

    private void AddScore(int score)
    {
        playerScore += score;
        ScoreText.text = "Score\n" + ZerosCheck() + playerScore;
        Debug.Log(playerScore);
        if (playerScore > SavedScore.Score)
        {
            SavedScore.Score = playerScore;
            SavedScore.HiScoreText = "HiScore\n" + ZerosCheck() + playerScore;
        }
    }

    private string ZerosCheck()
    {
        if (playerScore < 100)
        {
            return "00";
        }

        if (playerScore < 1000)
        {
            return "0";
        }

        return "";
    }
}
