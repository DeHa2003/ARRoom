using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    private static Coroutines instance
    {
        get
        {
            if(m_instance == null)
            {
                var go = new GameObject("[COROUTINE MANAGER]");
                m_instance = go.AddComponent<Coroutines>();
                DontDestroyOnLoad(go);
            }
            return m_instance;
        }
    }

    private static IEnumerator currentIenumerator;

    private static Coroutines m_instance;

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return instance.StartCoroutine(enumerator);
    }

    public static void Start_Coroutine(IEnumerator enumerator)
    {
        currentIenumerator = enumerator;
        instance.StartCoroutine(enumerator);
    }

    public static void Start_CoroutineAsync(IEnumerator enumerator)
    {
        instance.StartCoroutine(enumerator);
    }

    public static void Destroy_Coroutine()
    {
        instance.StopCoroutine(currentIenumerator);
        currentIenumerator = null;
    }

    public static void StopRoutine(Coroutine coroutine)
    {
        instance.StopCoroutine(coroutine);
    }
}
