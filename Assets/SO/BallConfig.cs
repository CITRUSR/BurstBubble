using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BallConfig", menuName = "BurstBubble/BallConfig", order = 0)]
public class BallConfig : ScriptableObject
{
    public Ball BallPrefab;
    public GameObject DestroyParticle;
    //public BallParameters parameters;
    //public float Size;
    //public float LifeTime;
    //public float SpawnTime;
    //public int Score;
}
