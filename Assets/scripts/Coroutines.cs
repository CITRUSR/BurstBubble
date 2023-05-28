using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    private static Coroutines Instance
    {
        get
        {
            if (_instance == null)
            {
                var inst = new GameObject("CorouniteManager");
                _instance = inst.AddComponent<Coroutines>();
                DontDestroyOnLoad(inst);
            }
            return _instance;
        }
    }
    private static Coroutines _instance;

    public static Coroutine StartRoutine(IEnumerator Coroutine)
    {
        return Instance.StartCoroutine(Coroutine);
    }

    public static void StopRoutine(Coroutine Coroutine)
    {
        Instance.StopCoroutine(Coroutine);
    }
}
