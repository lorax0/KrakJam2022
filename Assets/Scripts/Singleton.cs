using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (instance != null)
            Debug.LogError($"Singleton of type: {typeof(T)} already exists!");
        else
            instance = this as T;

        DontDestroyOnLoad(instance);
    }
}