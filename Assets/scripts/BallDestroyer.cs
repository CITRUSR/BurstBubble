using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer
{
    public void Destroy(Ball ball)
    {
        Object.Destroy(ball.gameObject);
    }
    public void Destroy(Ball[] balls)
    {
        foreach (var obj in balls)
        {
            Object.Destroy(obj.gameObject);
        }
    }
}
