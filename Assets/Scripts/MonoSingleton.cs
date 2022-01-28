using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static bool isPersistent = false;
    private static bool isQuiting = false;
    private static T instance = null;
    private static readonly object lockInstance = new object();

    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();
            if(instance == null)
            {
                instance = GetComponent<T>();
            }
        }
        else
        {
            Debug.LogError($"Singleton of type: {typeof(T)} already exists!");
            Destroy(this);
        }

        if (isPersistent)
        {
            DontDestroyOnLoad(this);
        }
    }

    protected virtual void OnApplicationQuit()
    {
        isQuiting = true;
    }
}