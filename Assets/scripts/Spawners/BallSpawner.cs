using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner
{
    private BallFactory _ballFactory;
    private BallConfig _ballConfig;
    private BallPositionFinder _ballPositionFinder;

    private Coroutine _routine;

    public BallSpawner(BallFactory BallFactory, BallConfig BallConfig, BallPositionFinder ballPositionFinder)
    {
        _ballFactory = BallFactory;
        _ballConfig = BallConfig;
        _ballPositionFinder = ballPositionFinder;
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            _ballFactory.Create(_ballPositionFinder.FindRandomPos());
            yield return new WaitForSeconds(_ballConfig.BallPrefab.Parameters.SpawnTime);
        }
    }

    public void StartSpawn()
    {
        _routine = Coroutines.StartRoutine(Spawn());
    }

    public void StopSpawn()
    {
        Coroutines.StopRoutine(_routine);
    }
}
