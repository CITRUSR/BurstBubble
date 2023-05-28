using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChangedEvent
{
    public readonly int Score;

    public ScoreChangedEvent(int score)
    {
        Score = score;
    }
}
