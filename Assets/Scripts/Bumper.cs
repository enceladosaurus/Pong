using System.Collections.Specialized;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public enum Mode
    {
        Vertical, Horizontal
    }
    public Mode mode = Mode.Vertical;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            HandleBallCollision(ball);
            GetComponent<AudioSource>().Play();
        }
    }
    void HandleBallCollision(Ball ball)
    {
        if (mode == Mode.Vertical)
        {
            ball.GetComponent<Rigidbody2D>().velocity *= new Vector2(1, -1);
        }
        else if (mode == Mode.Horizontal)
        {
            ball.GetComponent<Rigidbody2D>().velocity *= new Vector2(-1, 1);
        }
    }
}
