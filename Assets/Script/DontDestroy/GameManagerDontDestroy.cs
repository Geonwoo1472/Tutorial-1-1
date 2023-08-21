using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDontDestroy : MonoBehaviour
{
    public static GameManagerDontDestroy instance;
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
