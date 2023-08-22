using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemDontDestroy : MonoBehaviour
{
    public static EventSystemDontDestroy instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
