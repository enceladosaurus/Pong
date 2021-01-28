using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public enum Side{Right, Left};
    public Side side = Side.Left;
    public ScoreController scoreController = null;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            if (side == Side.Left)
            {
                scoreController.IncrementRightScore();
            }
            else
            {
                scoreController.IncrementLeftScore();
            }
            GetComponent<AudioSource>().Play();
        }
    }
}