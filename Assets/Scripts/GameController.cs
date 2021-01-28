using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball = null;
    private bool awaitingServe = true;
    private void Update()
    {
        if (!awaitingServe) 
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Serve();
        }     
    }
    public void EndRound()
    {
        awaitingServe = true;
        // reset ball position
        ball.transform.position = new Vector2(
            0,
            Random.Range(-5.0f, 5.0f));
        // turn off the ball sprite
        ball.SetActive(false);
    }
    private void Serve() 
    {
        awaitingServe = false;
        ball.SetActive(true);
    }

}
