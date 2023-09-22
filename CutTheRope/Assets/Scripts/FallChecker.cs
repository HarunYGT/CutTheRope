using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallChecker : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Obstacle"))
        {
            gameManager.ObjectFall();
        }
        else if (col.CompareTag("Ball"))
        {
            gameManager.BallFall();
        }
    }
}
