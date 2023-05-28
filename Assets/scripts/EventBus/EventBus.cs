using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class EventBus
{
    private Dictionary<Type, List<object>> _signalsCallback = new Dictionary<Type, List<object>>();

    public void Subscribe<T>(Action<T> callback)
    {
        var type = typeof(T);
        if (_signalsCallback.ContainsKey(type))
        {
            _signalsCallback[type].Add(callback);
        }
        else
        {
            _signalsCallback.Add(type, new List<object>() { callback });
        }
    }

    public void Unubscribe<T>(Action<T> callback)
    {
        var type = typeof(T);
        if (_signalsCallback.ContainsKey(type))
        {
            _signalsCallback[type].Remove(callback);
        }
    }

    public void Invoke<T>(T signal)
    {
        var type = typeof(T);
        if (_signalsCallback.ContainsKey(type))
        {
            foreach (var obj in _signalsCallback[type].ToList())
            {
                var Callback = obj as Action<T>;
                Callback?.Invoke(signal);
            }
        }
    }
}
