using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDifficultGame
{
    void Difficulting(ScoreChangedEvent scoreChangedEvent);
    void BallRefresh(Ball ball);
}
