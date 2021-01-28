using UnityEngine;
using System.Collections.Generic;

public class PlayerPaddle : Paddle
{
    private enum State
    {
        Up, Down
    }

    private HashSet<State> inputset = new HashSet<State>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            inputset.Add(State.Up);
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            inputset.Remove(State.Up);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            inputset.Add(State.Down);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            inputset.Remove(State.Down);
        }
    }

    void FixedUpdate()
    {
        if (!hitTopBumper && inputset.Contains(State.Up) && !inputset.Contains(State.Down))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, moveSpeed);
        }

        else if (!hitBotBumper && inputset.Contains(State.Down) && !inputset.Contains(State.Up))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -moveSpeed);
        }

        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
        }

    }
}
