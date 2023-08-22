using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalogManagerDontDestroy : MonoBehaviour
{
    public static DalogManagerDontDestroy instance;
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
