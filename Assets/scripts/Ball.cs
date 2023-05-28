using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Ball : MonoBehaviour, IPointerClickHandler
{
    public BallParameters Parameters;

    [SerializeField] private BallConfig _ballConfig;

    private BallDestroyer _destroyer;
    private ScoreCounter _scoreCounter;
    private LifeCounter _lifeCounter;
    public void Init(ScoreCounter scoreCounter, LifeCounter LifeCounter,BallDestroyer BallDestroyer)
    {
        _scoreCounter = scoreCounter;
        _lifeCounter = LifeCounter;
        _destroyer = BallDestroyer;

        transform.localScale = new Vector2(Parameters.Size, Parameters.Size);
        StartCoroutine(LifeCycle());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _scoreCounter.AddScore(_ballConfig.BallPrefab.Parameters.Score);
        Instantiate(_ballConfig.DestroyParticle, transform.position, Quaternion.identity);
        _destroyer.Destroy(this);
    }

    private IEnumerator LifeCycle()
    {
        yield return new WaitForSeconds(_ballConfig.BallPrefab.Parameters.LifeTime);
        _lifeCounter.RemoveLife(Parameters.Damage);
        _destroyer.Destroy(this);
    }
}