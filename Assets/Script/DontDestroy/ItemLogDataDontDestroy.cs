using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogDataDontDestroy : MonoBehaviour
{
    public static ItemLogDataDontDestroy instance;
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
