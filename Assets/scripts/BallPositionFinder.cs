using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPositionFinder
{
    private Camera _camera;

    public BallPositionFinder(Camera camera)
    {
        _camera = camera;
    }

    public Vector2 FindRandomPos()
    {
        float camHeight = _camera.orthographicSize;
        float camWidth = _camera.aspect * camHeight;

        float camMinX = _camera.transform.position.x - camWidth;
        float camMaxX = _camera.transform.position.x + camWidth;

        float CamMinY = _camera.transform.position.y - camHeight;
        float camMaxY = _camera.transform.position.y + camHeight;

        float RandomX = Random.Range(camMinX, camMaxX);
        float RandomY = Random.Range(CamMinY, camMaxY);

        return new Vector2(RandomX, RandomY);
    }
}
