using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeChangedEvent : MonoBehaviour
{
    public readonly int Life;

    public LifeChangedEvent(int life)
    {
        Life = life;
    }
}
