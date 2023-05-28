using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericFactory<T> where T : Object
{
    protected T _prefab;

    public virtual T Create(Vector2 pos)
    {
        var obj = Object.Instantiate(_prefab, pos, Quaternion.identity);

        return obj;
    }
}
