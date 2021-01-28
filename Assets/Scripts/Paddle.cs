using System.Security.Cryptography;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private const float MaxBounceAngleRadians = 75.0f * Mathf.Deg2Rad;
    public float moveSpeed;
    protected bool hitTopBumper = false;
    protected bool hitBotBumper = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        var bumper = other.GetComponent<Bumper>();

        if (bumper != null) 
        {
            HandleBumperCollision(bumper);
        }
        var ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            HandleBallCollision(ball);
        }
    }

    private void HandleBumperCollision(Bumper bumper)
    {
        if (this.transform.position.y > bumper.transform.position.y)
        {
            hitBotBumper = true;
        }

        if (this.transform.position.y < bumper.transform.position.y)
        {
            hitTopBumper = true;
        }
    }

    private void HandleBallCollision(Ball ball)
    {
        Vector2 paddleSize = GetComponent<BoxCollider2D>().size;

        Vector2 relativeIntersect = ball.transform.position - this.transform.position; 
        
        Vector2 normalizedIntersect = new Vector2(
            Mathf.CeilToInt(relativeIntersect.x / (paddleSize.x / 2.0f)),
            relativeIntersect.y / (paddleSize.y / 2.0f));

        float bounceAngle = normalizedIntersect.y * MaxBounceAngleRadians;
        float ballSpeed = ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        float speedMultiplierY = 1.0f + Mathf.Abs(normalizedIntersect.y); 
        float adjustedDirectionX = normalizedIntersect.x > 0 ? 1.0f : -1.0f;

        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(
            ballSpeed * adjustedDirectionX * Mathf.Cos(bounceAngle),
            ballSpeed * speedMultiplierY * Mathf.Sin(bounceAngle)
        );
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var bumper = other.GetComponent<Bumper>();
        if (bumper != null)
        {
            HandleBumperExit(bumper);
        }
    }
    private void HandleBumperExit(Bumper bumper)
    {
        if (this.transform.position.y > bumper.transform.position.y)
        {
            hitBotBumper = false;
        }

        if (this.transform.position.y < bumper.transform.position.y)
        {
            hitTopBumper = false;
        }
    }
}
