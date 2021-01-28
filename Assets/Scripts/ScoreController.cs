using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameController gameController = null;
    public Sprite[] scoreSprites = null;
    public SpriteRenderer leftScoreSprite = null;
    public SpriteRenderer rightScoreSprite = null;
    public int maxScore = 3; 
    private int leftScore = 0;
    private int rightScore = 0; 
    public AudioClip leftWin = null;
    public AudioClip rightWin = null;

    public void IncrementLeftScore() 
    {
        gameController.EndRound();
        leftScore++;
        leftScoreSprite.sprite = scoreSprites[leftScore];
        if(leftScore == maxScore)
        {
           ResetScores();
           var audioSource = GetComponent<AudioSource>();
           audioSource.clip = leftWin;
           audioSource.PlayDelayed(2);
        } 
        //Debug.Log($"Left Goal: {leftScore}");
    }
    public void IncrementRightScore() 
    {
        gameController.EndRound();
        rightScore++;
        rightScoreSprite.sprite = scoreSprites[rightScore];
        if(rightScore == maxScore)
        {
            ResetScores();
            var audioSource = GetComponent<AudioSource>();
            audioSource.clip = rightWin;
            audioSource.PlayDelayed(2);
        }
        //Debug.Log($"Right Goal: {rightScore}");
    }
    private void ResetScores() 
    {
        rightScore = 0;
        leftScore = 0;
        rightScoreSprite.sprite = scoreSprites[rightScore];
        leftScoreSprite.sprite = scoreSprites[leftScore];
    }
}

