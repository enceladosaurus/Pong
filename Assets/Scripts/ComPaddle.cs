using System.Threading;
using UnityEngine;

public class ComPaddle : Paddle
{
    public Transform ball = null;
    void FixedUpdate()
    {
        if (ball == null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }

        float distanceFromBallHeight = ball.position.y - this.transform.position.y;
        float moveTolerance = moveSpeed * Time.fixedDeltaTime; 

        if (!hitTopBumper && distanceFromBallHeight > moveTolerance)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, moveSpeed);
        }
        else if (!hitBotBumper && distanceFromBallHeight < -moveTolerance)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -moveSpeed);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
