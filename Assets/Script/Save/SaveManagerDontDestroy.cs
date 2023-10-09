using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagerDontDestroy : MonoBehaviour
{
    public static SaveManagerDontDestroy instance;
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
